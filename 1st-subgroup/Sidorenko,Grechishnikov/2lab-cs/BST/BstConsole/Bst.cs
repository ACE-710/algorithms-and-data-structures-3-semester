using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

// ReSharper disable TailRecursiveCall

namespace BstConsole {
    public class Bst<T> where T : IComparable {
        private TreeNode<T> head;
        public int cnt { private set; get; }
        private int a;

        public int size { private set; get; }

        public bool isEmpty => size == 0;

        public BstIterator iterator;

        public T this[int i] => getValueByKey(i);

        public T getValueByKey(int i)
        {
            cnt++;
            if (head == null) throw new ApplicationException("Tree is empty");
            return head.key == i ? head.value : getValueByKey(head.key > i ? head.left : head.right, i);
        }

        private static T getValueByKey(TreeNode<T> node, int i) {
            if (node == null) throw new ApplicationException("No such key in tree");
            return node.key == i ? node.value : getValueByKey(node.key > i ? node.left : node.right, i);
        }
        
        public int getCount()//опрос числа узлов, просмотренных операцией
        {
            int temp = cnt;
            cnt = 0;
            return temp;
        }


        public void remove(int key) {
            if (head.key == key) {
                if (head.left == null && head.right == null) {
                    head = null;
                    size--;
                    cnt++;
                    return;
                }

                if (head.left != null) {
                    head = head.left;
                    size--;
                    cnt++;
                    return;
                }

                if (head.right != null) {
                    head = head.right;
                    size--;
                    cnt++;
                    return;
                }
            }

            if (head.left != null && head.right != null) {
                findAndDelete(head, head.key < key ? head.right : head.left, key,
                    head.key < key ? Side.Right : Side.Left);
            }
        }

        private void findAndDelete(TreeNode<T> parent, TreeNode<T> it, int key, Side side) {
            if (it.key == key) {
                size--;
                if (it.left == null && it.right == null) {
                    if (side == Side.Left) parent.left = null;
                    else parent.right = null;
                    return;
                }

                if (it.left != null) {
                    if (side == Side.Left) parent.left = it.left;
                    else parent.right = it.left;
                    return;
                }

                if (it.right != null) {
                    if (side == Side.Left) parent.left = it.right;
                    else parent.right = it.right;
                    return;
                }

                var nodeWithBiggestKeyChild = findNodeWithBiggestKey(it, it.left);
                var biggestKey = nodeWithBiggestKeyChild.right.key;
                nodeWithBiggestKeyChild.right = null;

                if (side == Side.Left) parent.left.key = biggestKey;
                else parent.right.key = biggestKey;
            }

            findAndDelete(it, it.key > key ? it.right : it.left, key,
                it.key > key ? Side.Right : Side.Left);
        }

        /// <summary>
        /// Finds child node with biggest key of provided node
        /// (Recursive function)
        /// </summary>
        /// <param name="parent">parent of  provided node</param>
        /// <param name="it">node that is "start point of searching"</param>
        /// <returns>node with biggest child</returns>
        private static TreeNode<T> findNodeWithBiggestKey(TreeNode<T> parent, TreeNode<T> it) {
            return it.right != null ? findNodeWithBiggestKey(it, it.right) : parent;
        }

        public void insert(int key, T value) {
            if (head == null) {
                head = new TreeNode<T>(key, value);
                iterator = new BstIterator(head);
                size++;
                cnt++;
            }
            else {
                insert(head, key, value);
                cnt++;
            }
        }

        private void insert(TreeNode<T> node, int key, T value)
        {
            a++;
            if (node.key > key) {
                if (node.left == null) {
                    node.left = new TreeNode<T>(key, value);
                    size++;
                }
                else {
                    insert(node.left, key, value);
                }
            }
            else if (node.key == key) {
                node.value = value;
            }
            else {
                if (node.right == null) {
                    node.right = new TreeNode<T>(key, value);
                    size++;
                }
                else {
                    insert(node.right, key, value);
                }
            }
        }

        public void traverseTree() {
            traverseNode(head);
            Console.WriteLine();
        }


        private static void traverseNode(TreeNode<T> node) {
            if (node.left != null) traverseNode(node.left);
            if (node.right != null) traverseNode(node.right);
            Console.Write(node.key + " ");
        }

        public void printTree() {
            BTreePrinter.print(head);
        }

        public int getWayLength() {
//            throw new NotImplementedException();
            var done = new ArrayList();
            var node = head;
            var lenght = 0;
            while (true) {
                if (node.left != null)
                    lenght++;

                if (node.right != null)
                    lenght++;
            }

            return lenght;
        }

        public void clear() {
            if (head == null) return;
            if (head.left == null && head.right == null) {
                head = null;
                return;
            }

            if (head.left != null) {
                clear(head.left);
                head.left = null;
            }

            if (head.right != null) {
                clear(head.right);
                head.right = null;
            }

            head = null;
            size--;
        }

        private void clear(TreeNode<T> node) {
            if (node.left != null) {
                clear(node.left);
                node.left = null;
            }

            if (node.right != null) {
                clear(node.right);
                node.right = null;
            }

            size--;
        }

        public int getTreeInternalWay() => getTreeInternalWay(head);

        private static int getTreeInternalWay(TreeNode<T> node, int depth = 0) {
            var leftDepth = 0;
            var rightDepth = 0;

            if (node.right != null) {
                rightDepth = getTreeInternalWay(node.right, depth + 1);// depth == 0 ? 1 : depth + depth);
            }

            if (node.left != null) {
                leftDepth = getTreeInternalWay(node.left, depth + 1);// depth == 0 ? 1 : depth + depth);
            }

            if (node.left != null || node.right != null)
                return leftDepth + rightDepth + depth;
            return depth;
        }


        private int getTreeDepth(TreeNode<T> node = null, int depth = 0, Side side = Side.None) {
            if (node == null) {
                return getTreeDepth(head);
            }

            var leftDepth = 0;
            var rightDepth = 0;

            if (node.right != null) {
                rightDepth = getTreeDepth(node.right, depth + 1, Side.Right);
            }

            if (node.left != null) {
                leftDepth = getTreeDepth(node.left, depth + 1, Side.Left);
            }


            if (depth == 1 && side == Side.Right) {
                for (var i = 0; i < depth; i++) {
                    Console.Write("    ");
                }

                Console.WriteLine(node.key);
                Console.WriteLine(head.key);
            }
            else if (node.key != head.key) {
                for (var i = 0; i < depth; i++) {
                    Console.Write("    ");
                }

                Console.WriteLine(node.key);
            }

            if (node.left != null || node.right != null)
                return leftDepth > rightDepth ? leftDepth : rightDepth;
            return depth;
        }

        private enum Side {
            Left,
            Right,
            None
        }

        public class BstIterator {
            private TreeNode<T> head;
            private TreeNode<T> cur;
            private TreeNode<T> parent;

            public BstIterator(TreeNode<T> head) {
                this.head = head;
                cur = head ?? throw new Exception("Tree is empty or iterator was not initialized properly");
            }

            public void placeOnMin() {
                cur = head ?? throw new Exception("Tree is empty or iterator was not initialized properly");

                if (cur.left == null) return;
                while (cur.left != null) {
                    parent = cur;
                    cur = cur.left;
                }
            }

            public bool checkState() => cur != null;

            public void placeOnMax() {
                cur = head ?? throw new Exception("Tree is empty or iterator was not initialized properly");

                if (cur.right == null) return;
                while (cur.right != null) {
                    parent = cur;
                    cur = cur.right;
                }
            }

            public T getValue() {
                if (cur == null) {
                    throw new Exception("Tree is empty or iterator was not initialized properly");
                }

                return cur.value;
            }

            public void placeLeft() {
                if (cur.left == null) {
                    if (parent.left == null || parent.left.key >= cur.key)
                        throw new Exception("No more elements");
                    if (parent.key < cur.key) cur = parent;
                }
                else cur = cur.left;
            }

            public void placeRight() {
                if (cur.right == null)
                    if (parent.right == null || parent.right.key == cur.key)
                        throw new Exception("No more elements");
                    else cur = parent;
                else cur = cur.right;
            }

            public void setValue(T value) {
                if (cur == null) {
                    throw new Exception("Tree is empty or iterator was not initialized properly");
                }

                cur.value = value;
            }
        }

        private static class BTreePrinter {
            private class NodeInfo {
                public TreeNode<T> node;
                public string text;
                public int startPos;

                public int size => text.Length;

                public int endPos {
                    get => startPos + size;
                    set => startPos = value - size;
                }

                public NodeInfo parent, left, right;
            }

            public static void print(TreeNode<T> root, int topMargin = 2, int leftMargin = 2) {
                if (root == null) return;
                var rootTop = Console.CursorTop + topMargin;
                var last = new List<NodeInfo>();
                var next = root;
                for (var level = 0; next != null; level++) {
                    var item = new NodeInfo {node = next, text = next.key.ToString(" 0 ")};
                    if (level < last.Count) {
                        item.startPos = last[level].endPos + 1;
                        last[level] = item;
                    }
                    else {
                        item.startPos = leftMargin;
                        last.Add(item);
                    }

                    if (level > 0) {
                        item.parent = last[level - 1];
                        if (next == item.parent.node.left) {
                            item.parent.left = item;
                            item.endPos = Math.Max(item.endPos, item.parent.startPos);
                        }
                        else {
                            item.parent.right = item;
                            item.startPos = Math.Max(item.startPos, item.parent.endPos);
                        }
                    }

                    next = next.left ?? next.right;
                    for (; next == null; item = item.parent) {
                        print(item, rootTop + 2 * level);
                        if (--level < 0) break;
                        if (item == item.parent.left) {
                            item.parent.startPos = item.endPos;
                            next = item.parent.node.right;
                        }
                        else {
                            if (item.parent.left == null)
                                item.parent.endPos = item.startPos;
                            else
                                item.parent.startPos += (item.startPos - item.parent.endPos) / 2;
                        }
                    }
                }

                Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
            }

            private static void print(NodeInfo item, int top) {
                swapColors();
                print(item.text, top, item.startPos);
                swapColors();
                if (item.left != null)
                    printLink(top + 1, "┌", "┘", item.left.startPos + item.left.size / 2, item.startPos);
                if (item.right != null)
                    printLink(top + 1, "└", "┐", item.endPos - 1, item.right.startPos + item.right.size / 2);
            }

            private static void printLink(int top, string start, string end, int startPos, int endPos) {
                print(start, top, startPos);
                print("─", top, startPos + 1, endPos);
                print(end, top, endPos);
            }

            private static void print(string s, int top, int left, int right = -1) {
                Console.SetCursorPosition(left, top);
                if (right < 0) right = left + s.Length;
                while (Console.CursorLeft < right) Console.Write(s);
            }

            private static void swapColors() {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = Console.BackgroundColor;
                Console.BackgroundColor = color;
            }
        }
    }

    public class TreeNode<T> where T : IComparable {
        public int key;
        public T value;
        public TreeNode<T> left;
        public TreeNode<T> right;

        public TreeNode(int key, T value) {
            this.key = key;
            this.value = value;
        }
    }
}