using System;
using System.Collections.Generic;
using System.Text;

using AcDb = Autodesk.AutoCAD.DatabaseServices;
using AcEd = Autodesk.AutoCAD.EditorInput;
using AcGe = Autodesk.AutoCAD.Geometry;
using AcAp = Autodesk.AutoCAD.ApplicationServices;

namespace CreateLayouts.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class JigPline : AcEd.DrawJig
    {
        private AcGe.Point3d m_startPt;
        private AcGe.Point3d m_endPt;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startPt"></param>
        public
        JigPline(AcGe.Point3d startPt)
        {
            m_startPt = startPt;
        }

        /// <summary>
        /// 
        /// </summary>
        public AcGe.Point3d
        EndPoint
        {
            get { return m_endPt; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="draw"></param>
        /// <returns></returns>
        protected override bool
        WorldDraw(Autodesk.AutoCAD.GraphicsInterface.WorldDraw draw)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="draw"></param>
        protected override void
        ViewportDraw(Autodesk.AutoCAD.GraphicsInterface.ViewportDraw draw)
        {
            draw.Geometry.WorldLine(m_startPt, m_endPt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prompts"></param>
        /// <returns></returns>
        protected override Autodesk.AutoCAD.EditorInput.SamplerStatus
        Sampler(Autodesk.AutoCAD.EditorInput.JigPrompts prompts)
        {
            AcEd.SamplerStatus samplerStatus = AcEd.SamplerStatus.NoChange;
            AcEd.JigPromptPointOptions opts = new AcEd.JigPromptPointOptions();

            opts.Message = "\nPoint";
            opts.BasePoint = m_startPt;
            opts.UseBasePoint = true;
            opts.UserInputControls |= AcEd.UserInputControls.AnyBlankTerminatesInput | AcEd.UserInputControls.NullResponseAccepted;

            AcEd.PromptPointResult result = prompts.AcquirePoint(opts);
            if (result.Status == AcEd.PromptStatus.OK)
            {
                if (m_endPt != result.Value)
                {
                    m_endPt = result.Value;
                    samplerStatus = AcEd.SamplerStatus.OK;
                }
            }

            return samplerStatus;
        }
    }
}
