using System;
using System.Collections.Generic;
using System.Text;

namespace AdventofCode {
    public class Tree {
        public Node root;

        private Node current;

        public void ProcessInput(int[] input) {
            CreateNode(input, null, 0);
        }

        private int[] CreateNode(int[] input, Node parent, int childIndex) {
            if (input.Length == 0)
                return input;


            Node n = new Node(input[0], input[1]);
            if (parent != null)
                parent.childNodes[childIndex] = n;
            else
                root = n;

            {
                int[] temp = new int[input.Length - 2];
                Array.Copy(input, 2, temp, 0, input.Length - 2);
                input = temp;
            }

            if (n.childNodes.Length > 0) {
                for (int i = 0; i < n.childNodes.Length; i++) {
                    input = CreateNode(input, n, i);
                }
            }

            if (input.Length == 0)
                return input;


            if (n.metaData.Length > 0) {
                if (n.metaData.Length <= input.Length) {
                    for (int i = 0; i < n.metaData.Length; i++) {
                        n.metaData[i] = input[i];
                    }
                    int[] temp = new int[input.Length - n.metaData.Length];
                    Array.Copy(input, n.metaData.Length, temp, 0, temp.Length);
                    input = temp;
                }
            }

            return input;
        }

        public int GetMeta() {
            if (root == null)
                return 0;

            return GetMeta(root);
        }

        private int GetMeta(Node n) {
            if (n == null)
                return 0;

            int meta = 0;

            foreach (Node child in n.childNodes)
                meta += GetMeta(child);

            foreach (int i in n.metaData)
                meta += i;

            return meta;
        }

        public int GetRootMeta() {
            if (root == null)
                return 0;

            return GetRootMeta(root);
        }

        private int GetRootMeta(Node n) {
            if (n == null)
                return 0;

            int meta = 0;

            if (n.childNodes.Length == 0) {
                meta += GetMeta(n);
            } else {
                foreach (int i in n.metaData) {
                    if (i == 0 || i > n.childNodes.Length)
                        continue;

                    meta += GetRootMeta(n.childNodes[i - 1]);
                }
            }

            return meta;
        }
    }


    public class Node {
        public Node[] childNodes;
        public int[] metaData;

        public Node(int Nodes, int metaDatas) {
            childNodes = new Node[Nodes];
            metaData = new int[metaDatas];
        }
    }
}
