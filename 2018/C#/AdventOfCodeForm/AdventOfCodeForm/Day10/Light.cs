using AdventOfCodeForm.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeForm.Day10 {
    public class Light {
        public Vector2D location;
        public Vector2D velocity;

        public Light(Vector2D location, Vector2D velocity) {
            this.location = location;
            this.velocity = velocity;
        }

        public void Update(int accel) {
            location += (velocity * accel);
        }

        public void Reverse(int accel) {
            location -= (velocity * accel);
        }

        public override string ToString() {
            return $"{{{location} - {velocity}}}";
        }
    }
}
