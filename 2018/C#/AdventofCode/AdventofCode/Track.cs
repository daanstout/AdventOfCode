using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventofCode {
    public class Cart {
        public enum dirs {
            left,
            right,
            up,
            down
        }

        public enum turns {
            left,
            forward,
            right
        }

        public int x;
        public int y;
        public dirs facing;
        public turns turn = turns.left;

        public Cart(int x, int y, char facing) {
            this.x = x;
            this.y = y;
            switch (facing) {
                case '^':
                    this.facing = dirs.up;
                    break;
                case '>':
                    this.facing = dirs.right;
                    break;
                case 'v':
                    this.facing = dirs.down;
                    break;
                case '<':
                    this.facing = dirs.left;
                    break;
            }
        }
    }

    public class Track {
        public enum dirs {
            leftRight = 0,
            upDown,
            topLeftBottomRight,
            bottomLeftTopRight,
            cross,
            none
        }

        public dirs direction;
        public bool hasCart = false;

        public Track(char dir) {
            char[] carts = new char[4] { '<', '^', '>', 'v' };
            if (carts.Contains(dir))
                hasCart = true;

            switch (dir) {
                case '>':
                case '<':
                case '-':
                    direction = dirs.leftRight;
                    break;
                case '\\':
                    direction = dirs.topLeftBottomRight;
                    break;
                case '|':
                case '^':
                case 'v':
                    direction = dirs.upDown;
                    break;
                case '/':
                    direction = dirs.bottomLeftTopRight;
                    break;
                case '+':
                    direction = dirs.cross;
                    break;
                default:
                    direction = dirs.none;
                    break;
            }
        }
    }

    public class Field {
        readonly Track[,] tracks = new Track[151, 150];
        List<Cart> carts = new List<Cart>();
        public Point collision;

        public Field(string field) {
            string[] fields = field.Split('\n');

            char[] cart = new char[4] { '^', '>', 'v', '<' };

            for (int x = 0; x < 151; x++) {
                for (int y = 0; y < 150; y++) {
                    tracks[x, y] = new Track(fields[y][x]);
                    if (cart.Contains(fields[y][x]))
                        carts.Add(new Cart(x, y, fields[y][x]));
                }
            }
        }

        public bool Tick() {
            foreach (Cart c in carts) {
                int nextX, nextY;
                if (c.facing == Cart.dirs.down || c.facing == Cart.dirs.up) {
                    nextX = c.x;
                    nextY = c.y + (c.facing == Cart.dirs.up ? -1 : 1);
                } else {
                    nextX = c.x + (c.facing == Cart.dirs.right ? 1 : -1);
                    nextY = c.y;
                }

                if (tracks[nextX, nextY].hasCart) {
                    collision = new Point(nextX, nextY);
                }

                tracks[c.x, c.y].hasCart = false;
                tracks[nextX, nextY].hasCart = true;

                if (tracks[nextX, nextY].direction == Track.dirs.bottomLeftTopRight) {
                    switch (c.facing) {
                        case Cart.dirs.up:
                            c.facing = Cart.dirs.right;
                            break;
                        case Cart.dirs.right:
                            c.facing = Cart.dirs.up;
                            break;
                        case Cart.dirs.left:
                            c.facing = Cart.dirs.down;
                            break;
                        case Cart.dirs.down:
                            c.facing = Cart.dirs.left;
                            break;
                    }
                } else if (tracks[nextX, nextY].direction == Track.dirs.topLeftBottomRight) {
                    switch (c.facing) {
                        case Cart.dirs.up:
                            c.facing = Cart.dirs.left;
                            break;
                        case Cart.dirs.left:
                            c.facing = Cart.dirs.up;
                            break;
                        case Cart.dirs.right:
                            c.facing = Cart.dirs.down;
                            break;
                        case Cart.dirs.down:
                            c.facing = Cart.dirs.right;
                            break;
                    }
                } else if (tracks[nextX, nextY].direction == Track.dirs.cross) {
                    if (c.turn != Cart.turns.forward) {
                        switch (c.facing) {
                            case Cart.dirs.up:
                                if (c.turn == Cart.turns.left)
                                    c.facing = Cart.dirs.left;
                                else if (c.turn == Cart.turns.right)
                                    c.facing = Cart.dirs.right;
                                break;
                            case Cart.dirs.left:
                                if (c.turn == Cart.turns.left)
                                    c.facing = Cart.dirs.down;
                                else if (c.turn == Cart.turns.right)
                                    c.facing = Cart.dirs.up;
                                break;
                            case Cart.dirs.right:
                                if (c.turn == Cart.turns.left)
                                    c.facing = Cart.dirs.up;
                                else if (c.turn == Cart.turns.right)
                                    c.facing = Cart.dirs.down;
                                break;
                            case Cart.dirs.down:
                                if (c.turn == Cart.turns.left)
                                    c.facing = Cart.dirs.right;
                                else if (c.turn == Cart.turns.right)
                                    c.facing = Cart.dirs.left;
                                break;
                        }
                    }
                }
                c.turn = (Cart.turns)((((int)c.turn) + 1) % 3);
            }

            return collision == Point.Empty;
        }
    }
}
