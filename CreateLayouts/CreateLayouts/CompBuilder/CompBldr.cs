using System;
using System.Diagnostics;
using System.Collections;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace CreateLayouts
{
    public abstract class CompBldr : TransactionHelper
    {
        // member variables
        protected BlockTableRecord m_blkRec = null;
        protected ObjectId m_blkDefId;
        protected ObjectIdCollection m_objIds = new ObjectIdCollection();
        protected Stack m_xformStack = new Stack();
        protected bool m_ignoreXform = false;

        public
        CompBldr(Database db)
        : base(db)
        {
            // init stack with identity matrix
            m_xformStack.Push(Matrix3d.Identity);
        }

        protected abstract void SetCurrentBlkTblRec();

        public ObjectId
        BlockDefId
        {
            get
            {
                Debug.Assert(m_blkDefId.IsNull == false);   // shouldn't be calling this if things haven't been started!
                return m_blkDefId;
            }
        }

        public override void
        Start()
        {
            // call base class to start a transaction
            base.Start();

            // call derived class to supply the block that we are drawing into.
            SetCurrentBlkTblRec();
            if (m_blkRec == null)
                throw (new System.Exception("No BlockTableRecord was set up!"));

            m_blkDefId = m_blkRec.ObjectId;
        }

        public virtual void
        Reset()
        {
            // reset the stack of xforms
            m_xformStack.Clear();

            // init stack with identity matrix
            m_xformStack.Push(Matrix3d.Identity);

            m_objIds.Clear();
        }


        public virtual void
        AddToDb(Entity ent)
        {
            Debug.Assert((m_db != null) && (m_trans != null) && (m_blkRec != null));

            // transform if not the identity matrix
            if ((m_ignoreXform == false) && (m_xformStack.Count > 1))
                ent.TransformBy(CurrentXform());

            // add to the current block tbl record and add to the transaction
            m_blkRec.AppendEntity(ent);

            m_objIds.Add(ent.ObjectId);   // keep track of everything we added just in case
            m_trans.AddNewlyCreatedDBObject(ent, true);
        }


        public virtual void
        AddToDbNoXform(Entity ent)
        {
            m_ignoreXform = true;
            AddToDb(ent);
            m_ignoreXform = false;
        }


        public virtual void
        SetToDefaultProps(Entity ent)
        {
            ent.SetDatabaseDefaults(m_db);
        }


        public void
        PushXform(Matrix3d mat)
        {
            Debug.Assert(m_xformStack.Count != 0);

            m_xformStack.Push(mat * CurrentXform());
        }


        public void
        PopXform()
        {
            Debug.Assert(m_xformStack.Count > 1);  // this means that someone has popped to many times - bad bad bad
            m_xformStack.Pop();
        }


        public Matrix3d
        CurrentXform()
        {
            Debug.Assert(m_xformStack.Count != 0);
            return (Matrix3d)m_xformStack.Peek();
        }
    }
}
