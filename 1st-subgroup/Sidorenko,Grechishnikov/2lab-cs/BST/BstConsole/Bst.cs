using System;

// ReSharper disable TailRecursiveCall

namespace BstConsole {
    public class Bst<T> where T : IComparable {
        private TreeNode<T> head;

        public int size { private set; get; }

        public bool isEmpty => size == 0;

        public BstIterator iterator;

        public T this[int i] => getValueByKey(i);

        private T getValueByKey(int i) {
            if (head == null) throw new ApplicationException("Tree is empty");
            return head.key == i ? head.value : getValueByKey(head.key > i ? head.left : head.right, i);
        }

        private static T getValueByKey(TreeNode<T> node, int i) {
            if (node == null) throw new ApplicationException("No such key in tree");
            return node.key == i ? node.value : getValueByKey(node.key > i ? node.left : node.right, i);
        }

        public void delete(int key) {
            if (head.key == key) {
                if (head.left == null && head.right == null) {
                    head = null;
                    size--;
                    return;
                }

                if (head.left != null) {
                    head = head.left;
                    size--;
                    return;
                }

                if (head.right != null) {
                    head = head.right;
                    size--;
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
            }
            else {
                insert(head, key, value);
            }
        }

        private void insert(TreeNode<T> node, int key, T value) {
            if (node.key > key) {
                if (node.left == null) {
                    node.left = new TreeNode<T>(key, value);
                    size++;
                }
                else {
                    insert(node.left, key, value);
                }
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

        public void printTree() {
            var depth = getTreeDepth();
            Console.WriteLine(depth);
        }

        public int getWayLength() {
            throw new NotImplementedException();
//            var node = head;
//            var size = 0;
//            while (true) {
//                
//                if (node.left != null)
//                    
//                    if (node.right != null)
//            }
        }

        private static void traverseNode(TreeNode<T> node) {
            if (node.left != null) traverseNode(node.left);
            if (node.right != null) traverseNode(node.right);
            Console.Write(node.key + " ");
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

        private int getTreeDepth(TreeNode<T> node = null, int depth = 0) {
            if (node == null) {
                return getTreeDepth(head);
            }
            var leftDepth = 0;
            var rightDepth = 0;

            if (node.left != null) leftDepth = getTreeDepth(node.left, depth + 1);
            if (node.right != null) rightDepth = getTreeDepth(node.right, depth + 1);

            return leftDepth > rightDepth ? leftDepth : rightDepth;
        }

        private enum Side {
            Left,
            Right
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
                if (cur.left == null)
                    if (parent.left == null || parent.left.key == cur.key) throw new Exception("No more eleme");
            }
            
            public void setValue(T value) {
                if (cur == null) {
                    throw new Exception("Tree is empty or iterator was not initialized properly");
                }

                cur.value = value;
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