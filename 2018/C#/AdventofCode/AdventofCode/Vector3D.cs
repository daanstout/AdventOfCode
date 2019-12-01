using System;
using System.Collections.Generic;
using System.Text;

namespace AdventofCode {
    public sealed class Vector3D {
        #region Variables
        public float x;
        public float y;
        public float z;
        #endregion
        #region Constructors
        public Vector3D() => x = y = z = 0;

        //public Vector3D(Vector2D vec) {
        //    x = vec.x;
        //    y = vec.y;
        //    z = 0;
        //}

        public Vector3D(Vector3D vec) {
            x = vec.x;
            y = vec.y;
            z = vec.z;
        }

        public Vector3D(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion
        #region Operator Overloads
        public static Vector3D operator +(Vector3D v1, Vector3D v2) => new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        //public static Vector3D operator +(Vector3D v1, Vector2D v2) => new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z);
        //public static Vector3D operator +(Vector2D v1, Vector3D v2) => new Vector3D(v1.x + v2.x, v1.y + v2.y, v2.z);

        public static Vector3D operator -(Vector3D v1, Vector3D v2) => new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        //public static Vector3D operator -(Vector3D v1, Vector2D v2) => new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z);
        //public static Vector3D operator -(Vector2D v1, Vector3D v2) => new Vector3D(v1.x - v2.x, v1.y - v2.y, v2.z);

        public static Vector3D operator *(Vector3D v, float f) => new Vector3D(v.x * f, v.y * f, v.z * f);
        public static Vector3D operator *(Vector3D v, int i) => new Vector3D(v.x * i, v.y * i, v.z * i);
        public static Vector3D operator *(float f, Vector3D v) => new Vector3D(v.x * f, v.y * f, v.z * f);
        public static Vector3D operator *(int i, Vector3D v) => new Vector3D(v.x * i, v.y * i, v.z * i);
        public static Vector3D operator *(Vector3D v1, Vector3D v2) => new Vector3D(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);

        public static Vector3D operator /(Vector3D v, float f) => new Vector3D(v.x / f, v.y / f, v.z / f);
        public static Vector3D operator /(Vector3D v, int i) => new Vector3D(v.x / i, v.y / i, v.z / i);
        public static Vector3D operator /(float f, Vector3D v) => new Vector3D(v.x / f, v.y / f, v.z / f);
        public static Vector3D operator /(int i, Vector3D v) => new Vector3D(v.x / i, v.y / i, v.z / i);
        public static Vector3D operator /(Vector3D v1, Vector3D v2) => new Vector3D(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);

        public static Vector3D operator %(Vector3D v1, Vector3D v2) => new Vector3D(v1.x % v2.x, v1.y % v2.y, v1.z % v2.z);
        public static Vector3D operator %(Vector3D v, int i) => new Vector3D(v.x % i, v.y % i, v.z % i);

        public static bool operator ==(Vector3D v1, Vector3D v2) => v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;
        public static bool operator !=(Vector3D v1, Vector3D v2) => v1.x != v2.z || v1.y != v2.y || v1.z != v2.z;
        #endregion
        #region Explicit Conversions
        //public static explicit operator Vector3D(Vector2D v) => new Vector3D(v);
        #endregion

        public void SetZero() => x = y = z = 0.0f;

        public bool IsZero() => x == 0 && y == 0 && z == 0;

        public float Length() => (float)Math.Sqrt(x * x + y * y + z * z);

        public float LengthSq() => x * x + y * y + z * z;

        public float Dot(Vector3D other) => x * other.x + y * other.y + z * other.z;

        public Vector3D Perp() => throw new NotImplementedException();

        public Vector3D GetReverse() => new Vector3D(-x, -y, -z);

        public float GetManhattan(Vector3D other) => Math.Abs(x - other.x) + Math.Abs(y - other.y) + Math.Abs(z - other.z);

        public void Normalize() {
            float vectorLength = Length();
            x /= vectorLength;
            y /= vectorLength;
            z /= vectorLength;
        }

        public void Truncate(float max) {
            if (Length() > max) {
                Normalize();

                x *= max;
                y *= max;
                z *= max;
            }
        }

        public float Distance(Vector3D other) {
            float dx = other.x - x;
            float dy = other.y - y;
            float dz = other.z - z;

            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public float DistanceSq(Vector3D other) {
            float dx = other.x - x;
            float dy = other.y - y;
            float dz = other.z - z;

            return dx * dx + dy * dy + dz * dz;
        }

        public void Reflect(Vector3D norm) {
            Vector3D result = new Vector3D(this);
            result += 2 * Dot(norm) * norm.GetReverse();

            x = result.x;
            y = result.y;
            z = result.z;
        }

        public void WrapAround(int maxX, int maxY, int maxZ) {
            if (x > maxX)
                x = 0;
            if (x < 0)
                x = maxX;

            if (y > maxY)
                y = 0;
            if (y < 0)
                y = maxY;

            if (z > maxZ)
                z = 0;
            if (z < 0)
                z = maxZ;
        }

        public void NotInsideRegion(Vector3D top_left, Vector3D bottom_right) {

        }

        public override bool Equals(object obj) {
            if (obj == null)
                return false;
            if (obj is Vector3D v)
                return this == v;
            return false;
        }

        public override int GetHashCode() {
            var hashCode = 1502939027;
            hashCode = hashCode * -1521134295 + x.GetHashCode();
            hashCode = hashCode * -1521134295 + y.GetHashCode();
            hashCode = hashCode * -1521134295 + z.GetHashCode();
            return hashCode;
        }

        public override string ToString() {
            return $"[{x}, {y}, {z}]";
        }
    }
}
