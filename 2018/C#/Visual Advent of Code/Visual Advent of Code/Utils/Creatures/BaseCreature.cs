using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Advent_of_Code.Utils.GridSystem;

namespace Visual_Advent_of_Code.Utils.Creatures {
    public class BaseCreature {
        public enum creatureTypes {
            elf,
            goblin
        }

        public creatureTypes type;

        public Point location;

        public bool hasMoved = false;

        public BaseCreature(Point loc) {
            location = loc;
        }

        public bool CalculateMove(Tile[,] grid) {
            hasMoved = true;

            List<BaseCreature> enemies = new List<BaseCreature>();

            //for (int x = 0; x < grid.GetLength(0); x++) {
            //    for (int y = 0; y < grid.GetLength(1); y++) {
            //        if (grid[x, y].creature.type != type)
            //            enemies.Add(grid[x, y].creature);
            //    }
            //}

            foreach (Tile t in grid)
                t.Reset();

            grid[location.X, location.Y].distance = 0;
            Queue<Tile> queue = new Queue<Tile>();
            queue.Enqueue(grid[location.X, location.Y]);
            List<Tile> reachable = new List<Tile>();

            while (queue.Count > 0) {
                Tile current = queue.Dequeue();
                Tile neighbour = null;

                if (current.coords.Y > 0) {
                    neighbour = grid[current.coords.X, current.coords.Y - 1];
                    if (!neighbour.scratch) {
                        neighbour.scratch = true;
                        if (neighbour.tileType != Tile.tiles.wall) {
                            neighbour.previous = current;
                            neighbour.distance = current.distance + 1;
                            queue.Enqueue(neighbour);
                            reachable.Add(neighbour);
                        }
                    }
                }
                if (current.coords.X > 0) {
                    neighbour = grid[current.coords.X - 1, current.coords.Y];
                    if (!neighbour.scratch) {
                        neighbour.scratch = true;
                        if (neighbour.tileType != Tile.tiles.wall) {
                            neighbour.previous = current;
                            neighbour.distance = current.distance + 1;
                            queue.Enqueue(neighbour);
                            reachable.Add(neighbour);
                        }
                    }
                }
                if (current.coords.X < grid.GetLength(0) - 1) {
                    neighbour = grid[current.coords.X + 1, current.coords.Y];
                    if (!neighbour.scratch) {
                        neighbour.scratch = true;
                        if (neighbour.tileType != Tile.tiles.wall) {
                            neighbour.previous = current;
                            neighbour.distance = current.distance + 1;
                            queue.Enqueue(neighbour);
                            reachable.Add(neighbour);
                        }
                    }
                }
                if (current.coords.Y < grid.GetLength(1) - 1) {
                    neighbour = grid[current.coords.X, current.coords.Y + 1];
                    if (!neighbour.scratch) {
                        neighbour.scratch = true;
                        if (neighbour.tileType != Tile.tiles.wall) {
                            neighbour.previous = current;
                            neighbour.distance = current.distance + 1;
                            queue.Enqueue(neighbour);
                            reachable.Add(neighbour);
                        }
                    }
                }

                if (current.creature != null)
                    if (current.creature.type != type)
                        enemies.Add(current.creature);
            }

            if (enemies.Count <= 0)
                return false;

            Tile closest = null;
            int distance = int.MaxValue;

            foreach(BaseCreature enemy in enemies) {
                List<Tile> tiles = new List<Tile>();
                if(enemy.location.Y > 0) {
                    Tile neighbour = grid[enemy.location.X, enemy.location.Y - 1];
                    if (neighbour.tileType == Tile.tiles.space) {
                        if (neighbour.scratch) {
                            if(closest == null) {
                                closest = neighbour;
                                distance = neighbour.distance;
                            }else if(closest.distance > neighbour.distance) {
                                closest = neighbour;
                                distance = neighbour.distance;
                            }else  if(closest.distance == neighbour.distance) {
                                if (neighbour.coords.Y < closest.coords.Y)
                                    closest = neighbour;
                                else if (neighbour.coords.Y == closest.coords.Y && neighbour.coords.X < closest.coords.X)
                                    closest = neighbour;
                            }
                        }
                    }
                }
                if(enemy.location.X > 0) {
                    Tile neighbour = grid[enemy.location.X - 1, enemy.location.Y];
                    if (neighbour.tileType == Tile.tiles.space) {
                        if (neighbour.scratch) {
                            if (closest == null) {
                                closest = neighbour;
                                distance = neighbour.distance;
                            } else if (closest.distance > neighbour.distance) {
                                closest = neighbour;
                                distance = neighbour.distance;
                            } else if (closest.distance == neighbour.distance) {
                                if (neighbour.coords.Y < closest.coords.Y)
                                    closest = neighbour;
                                else if (neighbour.coords.Y == closest.coords.Y && neighbour.coords.X < closest.coords.X)
                                    closest = neighbour;
                            }
                        }
                    }
                }
                if(enemy.location.X < grid.GetLength(0) - 1) {
                    Tile neighbour = grid[enemy.location.X + 1, enemy.location.Y];
                    if (neighbour.tileType == Tile.tiles.space) {
                        if (neighbour.scratch) {
                            if (closest == null) {
                                closest = neighbour;
                                distance = neighbour.distance;
                            } else if (closest.distance > neighbour.distance) {
                                closest = neighbour;
                                distance = neighbour.distance;
                            } else if (closest.distance == neighbour.distance) {
                                if (neighbour.coords.Y < closest.coords.Y)
                                    closest = neighbour;
                                else if (neighbour.coords.Y == closest.coords.Y && neighbour.coords.X < closest.coords.X)
                                    closest = neighbour;
                            }
                        }
                    }
                }
                if(enemy.location.Y < grid.GetLength(1) - 1) {
                    Tile neighbour = grid[enemy.location.X, enemy.location.Y + 1];
                    if (neighbour.tileType == Tile.tiles.space) {
                        if (neighbour.scratch) {
                            if (closest == null) {
                                closest = neighbour;
                                distance = neighbour.distance;
                            } else if (closest.distance > neighbour.distance) {
                                closest = neighbour;
                                distance = neighbour.distance;
                            } else if (closest.distance == neighbour.distance) {
                                if (neighbour.coords.Y < closest.coords.Y)
                                    closest = neighbour;
                                else if (neighbour.coords.Y == closest.coords.Y && neighbour.coords.X < closest.coords.X)
                                    closest = neighbour;
                            }
                        }
                    }
                }
            }

            if (distance <= 0)
                return true;

            while (closest.previous != grid[location.X, location.Y])
                closest = closest.previous;

            Move(grid, closest.coords);

            return false;
        }

        public void Move(Tile[,] grid, Point newPos) {
            grid[newPos.X, newPos.Y].creature = this;
            grid[location.X, location.Y].creature = null;
            location = newPos;
        }
    }
}
