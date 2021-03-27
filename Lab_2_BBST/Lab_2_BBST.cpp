#include<iostream>
#include<string>

using namespace std;

//BinaryTree starts
template <typename T>
struct TNode {
	T data;  //data members
	TNode<T>* left;
	TNode<T>* right;
	// constructor
	TNode(T d);
	int height;
};

template <typename T>
class BinaryTree {
public:
	BinaryTree();// constructor
	bool isEmpty() { return root == NULL; }
	void preorder();
	void inorder();
	void postorder();
	void makeEmpty();
	int size() { return size_rec(root); }
protected:
	TNode<T>* root;
	void preorder_rec(TNode<T>* p);
	void inorder_rec(TNode<T>* p);
	void postorder_rec(TNode<T>* p);
	int size_rec(TNode<T>* p);
	void makeEmpty_rec(TNode<T>* p);
};//class BinaryTree

template <typename T>
BinaryTree<T> ::BinaryTree() {
	root = NULL;
}

//constructor of TNode
template <typename T>
TNode<T>::TNode(T item) {
	data = item;
	left = right = NULL;
	height = 0;
}

template <typename T>
int height(TNode<T>* p) {
	return p == NULL ? -1 : p->height;
}

//preorder
template <typename T>
void BinaryTree<T>::preorder() {
	cout << "preorder sequence of nodes: \n";
	if (isEmpty())	cout << "tree is empty\n";
	else {
		preorder_rec(root);
		cout << "\n";
	}
}

template <typename T>
void BinaryTree<T>::preorder_rec(TNode<T>* p) {
	if (p != NULL) {
		cout << p->data << ", ";
		preorder_rec(p->left);
		preorder_rec(p->right);
	}
}

//inorder
template <typename T>
void BinaryTree<T>::inorder() {
	cout << "inorder sequence of nodes: \n";
	if (isEmpty()) cout << "tree is empty\n";
	else {
		inorder_rec(root);
		cout << "\n";
	}
}

template <typename T>
void BinaryTree<T>::inorder_rec(TNode<T>* p) {
	if (p != NULL) {
		inorder_rec(p->left);
		cout << p->data << ", ";
		inorder_rec(p->right);
	}
}

//postorser
template <typename T>
void BinaryTree<T>::postorder() {
	cout << "postorder sequence of nodes: \n";
	if (isEmpty()) cout << "tree is empty\n";
	else {
		postorder_rec(root);
		cout << "\n";
	}
}

template <typename T>
void BinaryTree<T>::postorder_rec(TNode<T>* p) {
	if (p != NULL) {
		postorder_rec(p->left);
		postorder_rec(p->right);
		cout << p->data << ", ";
	}
}

//makeEmpty	
template <typename T>
void BinaryTree<T>::makeEmpty() {
	TNode<T>* p = root;
	makeEmpty_rec(p);
	root = NULL;
}

template <typename T>
void BinaryTree<T>::makeEmpty_rec(TNode<T>* p) {
	if (p != NULL) {
		makeEmpty_rec(p->left);
		makeEmpty_rec(p->right);
		delete p;
	}
}

template <typename T>
int BinaryTree<T>::size_rec(TNode<T>* p) {
	if (p == NULL)	return 0;
	else return size_rec(p->left) + size_rec(p->right) + 1;
}

//BinaryTree finished
/////////////////////////////////////////////////////////////////////////////////////////////
//BalanceBinarySearchTree started
template <typename T>
class BalanceBinarySearchTree : public BinaryTree<T> {
protected:
	TNode<T>* addNode_rec(T item, TNode<T>* p);
public:
	BalanceBinarySearchTree() :BinaryTree<T>() {}  // Base class constructor is used.
	void addNode(T item);
};

// addNode
template <typename T>
void BalanceBinarySearchTree<T>::addNode(T item) {
	if (search(item)) cout << endl << item << " is dublicate;\n";
	else BinaryTree<T>::root = addNode_rec(item, BinaryTree<T>::root);
}

template <typename T>
TNode<T>* BalanceBinarySearchTree<T>::addNode_rec(T item, TNode<T>* p) {
	if (p == NULL) p = new TNode<T>(item);
	else if (item < p->data) p->left = addNode_rec(item, p->left);
	else p->right = addNode_rec(item, p->right);
	if (height(p->left) > height(p->right)) p->height = height(p->left) + 1;
	else p->height = height(p->right) + 1;
	balance(p);
	return p;
}

int main()
{
   
}