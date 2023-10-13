using System;
using Autodesk.AutoCAD.Geometry;


namespace CreateLayouts.Utils
{
    public class Ge
    {
        // predefined constants for common angles
        public const double kPi = 3.14159265358979323846;
        public const double kHalfPi = 3.14159265358979323846 / 2.0;
        public const double kTwoPi = 3.14159265358979323846 * 2.0;

        public const double kRad0 = 0.0;
        public const double kRad45 = 3.14159265358979323846 / 4.0;
        public const double kRad90 = 3.14159265358979323846 / 2.0;
        public const double kRad135 = (3.14159265358979323846 * 3.0) / 4.0;
        public const double kRad180 = 3.14159265358979323846;
        public const double kRad270 = 3.14159265358979323846 * 1.5;
        public const double kRad360 = 3.14159265358979323846 * 2.0;

        // predefined values for common Points and Vectors
        public static readonly Point3d kOrigin = new Point3d(0.0, 0.0, 0.0);
        public static readonly Vector3d kXAxis = new Vector3d(1.0, 0.0, 0.0);
        public static readonly Vector3d kYAxis = new Vector3d(0.0, 1.0, 0.0);
        public static readonly Vector3d kZAxis = new Vector3d(0.0, 0.0, 1.0);

        public Ge()
        {
        }

        public static double
        RadiansToDegrees(double rads)
        {
            return rads * (180.0 / kPi);
        }

        public static double
        DegreesToRadians(double degrees)
        {
            return degrees * (kPi / 180.0);
        }

        public static Point3d
        Midpoint(Point3d pt1, Point3d pt2)
        {
            Point3d newPt = new Point3d(((pt1.X + pt2.X) / 2.0),
                                        ((pt1.Y + pt2.Y) / 2.0),
                                        ((pt1.Z + pt2.Z) / 2.0));

            return newPt;
        }


    }
}
