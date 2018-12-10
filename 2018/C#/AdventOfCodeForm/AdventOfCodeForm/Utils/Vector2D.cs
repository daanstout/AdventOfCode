using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeForm.Utils {
    public class Vector2D {
        /// <summary>
        /// The X value
        /// </summary>
        public float x;
        /// <summary>
        /// The Y value
        /// </summary>
        public float y;

        /// <summary>
        /// Emtpy constructor, setting both values to 0
        /// </summary>
        public Vector2D() {
            x = y = 0.0f;
        }

        /// <summary>
        /// Creates a vector from an existing vector
        /// </summary>
        /// <param name="vec">The vector to copy</param>
        public Vector2D(Vector2D vec) {
            x = vec.x;
            y = vec.y;
        }

        /// <summary>
        /// Creates a vector from 2 values
        /// </summary>
        /// <param name="a">X</param>
        /// <param name="b">Y</param>
        public Vector2D(float a, float b) {
            x = a;
            y = b;
        }

        /// <summary>
        /// Sets both values to 0;
        /// </summary>
        public void SetZero() {
            x = y = 0.0f;
        }

        /// <summary>
        /// Checks whether both values are 0
        /// </summary>
        /// <returns>True if both values are 0, false otherwhys</returns>
        public bool isZero() {
            return x == 0 && y == 0;
        }

        /// <summary>
        /// Gives the length of the vector
        /// </summary>
        /// <returns>The length of the vector</returns>
        public float Length() {
            return (float)Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Gives the unsquared length of the vector
        /// </summary>
        /// <returns>The unsquared length of the vector</returns>
        public float LengthSq() {
            return (x * x + y * y);
        }

        /// <summary>
        /// Calculates the dot between 2 vectors
        /// </summary>
        /// <param name="other"></param>
        /// <returns>For normalized vectors Dot returns 1 if they point in exactly the same direction; -1 if they point in completely opposite directions; and a number in between for other cases (e.g. Dot returns zero if vectors are perpendicular)</returns>
        public float Dot(Vector2D other) {
            return x * other.x + y * other.y;
        }

        /// <summary>
        /// Normalizes the vector, putting both values between -1 and 1
        /// </summary>
        public void Normalize() {
            float vectorLength = Length();
            x /= vectorLength;
            y /= vectorLength;
        }

        /// <summary>
        /// checks on what side the other vector is
        /// </summary>
        /// <param name="other">The other vector</param>
        /// <returns>returns -1 if other is anti-clockwise of the vector and 1 if clockwise</returns>
        public int Sign(Vector2D other) {
            if (y * other.x > x * other.y)
                return -1;
            else
                return 1;
        }

        /// <summary>
        /// Creates a new vector that is perpandicular of this vector
        /// </summary>
        /// <returns>A perpandicular vector</returns>
        public Vector2D Perp() {
            return new Vector2D(-y, x);
        }

        /// <summary>
        /// Truncates the vector to the max value if it goes over it
        /// </summary>
        /// <param name="max">The max value</param>
        public void Truncate(float max) {
            if (Length() > max) {
                Normalize();

                x *= max;
                y *= max;
            }
        }

        /// <summary>
        /// Calculates the distance between 2 vectors
        /// </summary>
        /// <param name="other">The other vector</param>
        /// <returns>The distance between the 2 vectors</returns>
        public float Distance(Vector2D other) {
            float dx = other.x - x;
            float dy = other.y - y;

            return (float)Math.Sqrt(dy * dy + dx * dx);
        }

        /// <summary>
        /// Calculates the unsquared distance between 2 vectors
        /// </summary>
        /// <param name="other">The other vector</param>
        /// <returns>The unsquared distance between the 2 vectors</returns>
        public float DistanceSq(Vector2D other) {
            float dx = other.x - x;
            float dy = other.y - y;

            return (dy * dy + dx * dx);
        }

        /// <summary>
        /// Reflects the vector as if it was bouncing of a wall
        /// </summary>
        /// <param name="norm">A normalized vector</param>
        public void Reflect(Vector2D norm) {
            Vector2D result = new Vector2D(this);
            result += 2 * Dot(norm) * norm.GetReverse();
            x = result.x;
            y = result.y;
        }

        /// <summary>
        /// Reverses the vector
        /// </summary>
        /// <returns>The reversed vector</returns>
        public Vector2D GetReverse() {
            return new Vector2D(-x, -y);
        }

        /// <summary>
        /// Wraps the vector around a screen
        /// </summary>
        /// <param name="maxX">The max X value</param>
        /// <param name="maxY">The max Y value</param>
        public void WrapAround(int maxX, int maxY) {
            if (x > maxX)
                x = 0;
            if (x < 0)
                x = maxX;

            if (y > maxY)
                y = 0;
            if (y < 0)
                y = maxY;
        }

        /// <summary>
        /// Checks whether the vector is not within a given rectangle
        /// </summary>
        /// <param name="top_left">The top left corner</param>
        /// <param name="bot_rgt">The bottom right corner</param>
        /// <returns>True if it is NOT in the rectangle</returns>
        public bool NotInsideRegion(Vector2D top_left, Vector2D bot_rgt) {
            return (x < top_left.x) || (x > bot_rgt.x) || (y < top_left.y) || (y > bot_rgt.y);
        }

        /// <summary>
        /// Checks whether the vector is within a given rectangle
        /// </summary>
        /// <param name="top_left">The top left corner</param>
        /// <param name="bot_rgt">The bottom right corner</param>
        /// <returns>True if it IS in the rectangle</returns>
        public bool InsideRegion(Vector2D top_left, Vector2D bot_rgt) {
            return !((x < top_left.x) || (x > bot_rgt.x) || (y < top_left.y) || (y > bot_rgt.y));
        }

        /// <summary>
        /// Checks whether the first is within view of the second
        /// </summary>
        /// <param name="posFirst">Position of the first vector</param>
        /// <param name="facingFirst">Heading of the first vector</param>
        /// <param name="posSecond">Position of the second vector</param>
        /// <param name="fov">FOV of the first vector</param>
        /// <returns></returns>
        public bool isSecondInFOVOfFirst(Vector2D posFirst, Vector2D facingFirst, Vector2D posSecond, float fov) {
            Vector2D toTarget = Vec2DNormalize(posSecond - posFirst);

            return facingFirst.Dot(toTarget) >= Math.Cos(fov / 2);
        }

        /// <summary>
        /// Normalizes a vector
        /// </summary>
        /// <param name="v">The vector to be normalized</param>
        /// <returns>A normalized vector</returns>
        public static Vector2D Vec2DNormalize(Vector2D v) {
            Vector2D vec = v;

            float vector_length = vec.Length();

            vec.x /= vector_length;
            vec.y /= vector_length;

            return vec;
        }

        /// <summary>
        /// Gets the distance between 2 vectors
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vectro2 </param>
        /// <returns>The distance between the 2 vectors</returns>
        public static float Vec2DDistance(Vector2D v1, Vector2D v2) {
            float ySep = v2.y - v1.y;
            float xSep = v2.x - v1.x;

            return (float)Math.Sqrt(ySep * ySep + xSep * xSep);
        }

        /// <summary>
        /// Gets the unsquared distance between 2 vectors
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2</param>
        /// <returns>The unsquared distance between the 2 vectors</returns>
        public static float Vec2DDistanceSq(Vector2D v1, Vector2D v2) {
            float ySep = v2.y - v1.y;
            float xSep = v2.x - v1.x;

            return ySep * ySep + xSep * xSep;
        }

        /// <summary>
        /// Gets the length of the vector
        /// </summary>
        /// <param name="v">The vector</param>
        /// <returns>The length of the vector</returns>
        public static float Vec2DLength(Vector2D v) {
            return (float)Math.Sqrt(v.x * v.x + v.y * v.y);
        }

        /// <summary>
        /// Gets the unsquared length of the vector
        /// </summary>
        /// <param name="v">The vector</param>
        /// <returns>The unsquared length of the vector</returns>
        public static float Vec2DLengthSq(Vector2D v) {
            return v.x * v.x + v.y * v.y;
        }

        // OPERATOR OVERLOADING
        public static Vector2D operator +(Vector2D a, Vector2D b) {
            return new Vector2D(a.x + b.x, a.y + b.y);
        }

        public static Vector2D operator -(Vector2D a, Vector2D b) {
            return new Vector2D(a.x - b.x, a.y - b.y);
        }

        public static Vector2D operator *(Vector2D v, float f) {
            return new Vector2D(v.x * f, v.y * f);
        }
        public static Vector2D operator *(float f, Vector2D v) {
            return new Vector2D(v.x * f, v.y * f);
        }

        public static Vector2D operator /(Vector2D v, float f) {
            return new Vector2D(v.x / f, v.y / f);
        }

        public static Vector2D operator /(float f, Vector2D v) {
            return new Vector2D(v.x / f, v.y / f);
        }

        // IMPLICIT CONVERTIONS
        public static implicit operator Point(Vector2D v) {
            return new Point((int)v.x, (int)v.y);
        }

        public static implicit operator Vector2D(Point p) {
            return new Vector2D(p.X, p.Y);
        }

        public static implicit operator PointF(Vector2D v) {
            return new PointF(v.x, v.y);
        }

        public static implicit operator Vector2D(PointF p) {
            return new Vector2D(p.X, p.Y);
        }

        public static implicit operator Size(Vector2D v) {
            return new Size((int)v.x, (int)v.y);
        }

        public static implicit operator Vector2D(Size s) {
            return new Vector2D(s.Width, s.Height);
        }

        public static implicit operator SizeF(Vector2D v) {
            return new SizeF(v.x, v.y);
        }

        // STATIC VALUES
        public static readonly Vector2D Up = new Vector2D(0, -1);
        public static readonly Vector2D Right = new Vector2D(1, 0);
        public static readonly Vector2D Down = new Vector2D(0, 1);
        public static readonly Vector2D Left = new Vector2D(-1, 0);
        public static readonly Vector2D Zero = new Vector2D(0, 0);

        /// <summary>
        /// Checks whether the 2 vectors are equal
        /// </summary>
        /// <param name="obj">The other vector</param>
        /// <returns>true if the vectors are equal</returns>
        public override bool Equals(object obj) {
            if (obj == null)
                return false;
            else if (obj is Vector2D v)
                return (x.Equals(v.x) && y.Equals(v.y));
            else
                return false;
        }

        /// <summary>
        /// Gets the hashcode of the vector
        /// </summary>
        /// <returns>The hashcode</returns>
        public override int GetHashCode() {
            var hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Returns a string of the 2 vectors
        /// </summary>
        /// <returns>A string as followed: "[x, y]"</returns>
        public override string ToString() {
            return String.Format("[{0}, {1}]", x, y);
        }
    }
}
