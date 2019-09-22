#pragma once

template<typename T>
class List {
    struct Node {
        T data;
        Node *next;

        Node(int i) : data(i), next(0) {};
    };

public:
    List() : head() {}

    int getSize();

    void add(T x);

    void add(int pos, T x);

    bool contains(T x);

    int find(T x);

    void clear();

    T get(int pos);

    bool isEmpty();

    void remove(T x);

    void del(int pos);

    Node *head;
private:
    int size = 0;
};

template<typename T>
void List<T>::add(T x) {
    if (size == 0) {
        head = new Node(x);
    } else {
        Node *n;
        int i;
        for (n = head, i = 0; n; n = n->next, i++) {
            if (i == size - 1) break;
        }
        n->next = new Node(x);
    }
    size++;
}

template<typename T>
inline void List<T>::add(int position, T x) {
    Node *n;
    Node *prev = head;
    Node *node = new Node(x);
    int pos = 0;
    if (position >= size) return;
    for (n = head; n; n = n->next) {
        if (pos == position) {
            if (n != head) {
                prev->next = node;
                node->next = n;
            }
            size++;
        }
        prev = n;
        pos++;
    }
}

template<typename T>
int List<T>::getSize() {
    return size;
}

template<typename T>
bool List<T>::contains(T x) {
    Node *n;
    for (n = head; n; n = n->next) {
        if (n->data == x) return true;
    }
    return false;
}

template<typename T>
void List<T>::remove(T x) {
    Node *n;
    Node *prev = head;
    for (n = head; n; n = n->next) {
        if (n->data == x) {
            if (n != head) prev->next = n->next;
            size--;
        }
        prev = n;
    }
}

template<typename T>
void List<T>::del(int position) {
    Node *n;
    Node *prev = head;
    int pos = 0;
    if (position >= size) return;
    for (n = head; n; n = n->next) {
        if (pos == position) {
            if (n != head) prev->next = n->next;
            size--;
        }
        prev = n;
        pos++;
    }
}

template<typename T>
int List<T>::find(T x) {
    Node *n;
    int pos = 0;
    for (n = head; n; n = n->next) {
        if (n->data == x) return pos;
        pos++;
    }
    return -1;
}

template<typename T>
inline void List<T>::clear() {
    head = 0;
}

template<typename T>
inline T List<T>::get(int pos) {
    Node *node = head;
    if (pos >= size) return -1;
    for (int i = 0; i < pos; i++) {
        node = node->next;
    }
    return node->data;
}

template<typename T>
inline bool List<T>::isEmpty() {
    return size == 0;
}
