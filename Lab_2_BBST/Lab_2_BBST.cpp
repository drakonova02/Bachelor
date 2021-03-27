﻿#include<iostream>
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
	bool search_rec(T item, TNode<T>* p);
	TNode<T>* deleteNode_rec(T item, TNode<T>* p);
	TNode<T>* delete_NodeFound(TNode<T>* p);
	void balance(TNode<T>*& p);
	void print_rec(TNode<string>* p, TNode<string>* following, int level);
	void print_rec(TNode<int>* p, TNode<int>* following, int level);
	void rotateLeftChild(TNode<T>*& p);
	void rotateRightChild(TNode<T>*& p);
	void doubleLeftChild(TNode<T>*& p);
	void doubleRightChild(TNode<T>*& p);
	void printSorted_ascen(TNode<T>* p);
	void printSorted_descen(TNode<T>* p);
	void countNode_rec(TNode<T>* p, int& sum);
	void sumKeys_rec(TNode<int>* p, int& sum);
	void deleteEven_rec(TNode<int>* p);
	int findMax(TNode<int>* p);
	int findMin(TNode<int>* p);
	void findMiddle_rec(TNode<int>* p, int mid, int n, int& node);
	TNode<int>* findSecondLargest_rec(TNode<int>* p, int max_node);
	void copyBBST_rec(TNode<T>* p, BalanceBinarySearchTree<T>& copy);
	void addcopy(int item);
	TNode<T>* addcopy_rec(int item, TNode<T>* p);
	void insertBBST_rec(TNode<T>* p);
public:
	BalanceBinarySearchTree() :BinaryTree<T>() {}  // Base class constructor is used.
	void addNode(T item);
	bool search(T item);
	void deleteNode(T item);
	void print();
	void printSorted();
	int countNode();
	int sumKeys();
	void deleteEven();
	int findMiddle();
	int findSecondLargest();
	BalanceBinarySearchTree<T> copyBBST();
	void insertBBST(BalanceBinarySearchTree<T>B);
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

//search
template <typename T>
bool BalanceBinarySearchTree<T>::search(T item) {
	return search_rec(item, BinaryTree<T>::root);
}

template <typename T>
bool BalanceBinarySearchTree<T>::search_rec(T item, TNode<T>* p) {
	if (p == NULL)		return false;
	if (p->data == item)	return true;
	else if (p->data > item)	 return search_rec(item, p->left);
	else return search_rec(item, p->right);
}

//DeleteNode
template <typename T>
void BalanceBinarySearchTree<T>::deleteNode(T item) {
	if (search(item)) BinaryTree<T>::root = deleteNode_rec(item, BinaryTree<T>::root);
	else cout << "Item not foud: item not deleted\n";
}

template <typename T>
TNode<T>* BalanceBinarySearchTree<T>::deleteNode_rec(T item, TNode<T>* p) {
	if (item < p->data)		p->left = deleteNode_rec(item, p->left);
	else  if (item > p->data)	p->right = deleteNode_rec(item, p->right);
	else p = delete_NodeFound(p);
	balance(p);
	return p;
}

template <typename T>
TNode<T>* BalanceBinarySearchTree<T>::delete_NodeFound(TNode<T>* p) {
	if (p->left == NULL) {
		TNode<T>* temp = p;
		p = p->right;
		delete temp;
		return p;
	}
	else if (p->right == NULL) {
		TNode<T>* temp = p;
		p = p->left;
		delete temp;
		return p;
	}
	else
	{
		TNode<T>* p1 = p->right;
		while (p1->left != NULL) p1 = p1->left;
		p->data = p1->data;
		p->right = deleteNode_rec(p->data, p->right);
		return p;
	}
}

//balance
template <typename T>
void BalanceBinarySearchTree<T>::balance(TNode<T>*& p) {
	if (p == NULL) return;

	if (height(p->left) - height(p->right) > 1) {
		if (height(p->left->left) >= height(p->left->right)) rotateLeftChild(p);
		else doubleLeftChild(p);
	}
	else if (height(p->right) - height(p->left) > 1) {
		if (height(p->right->right) >= height(p->right->left)) rotateRightChild(p);
		else doubleRightChild(p);
		p->height = max(height(p->left), height(p->right)) + 1;
	}
}

//print
template <typename T>
void BalanceBinarySearchTree<T>::print() {
	cout << endl;
	if (BinaryTree<T>::isEmpty()) cout << "tree is empty\n";
	else {
		print_rec(BinaryTree<T>::root, NULL, 0);
		cout << "\n";
	}
}

template <>
void BalanceBinarySearchTree<string>::print_rec(TNode<string>* p, TNode<string>* following, int level) {
	if (following != NULL) level += (following->data).length();
	for (int i = 0; i < level; ++i) cout << ' ';
	cout << p->data << endl;
	++level;
	if (p->left) print_rec(p->left, p, level);
	else cout << endl;
	if (p->right) print_rec(p->right, p, level);
}

template <>
void BalanceBinarySearchTree<int>::print_rec(TNode<int>* p, TNode<int>* following, int level) {
	int z = 0;
	if (following != NULL) z = following->data;
	while (z != 0) {
		++level;
		z /= 10;
	}
	for (int i = 0; i < level; ++i) cout << " ";
	cout << p->data << " " << endl;
	++level;
	if (p->left) print_rec(p->left, p, level);
	else cout << endl;
	if (p->right) print_rec(p->right, p, level);
}

//rotations
template <typename T>
void BalanceBinarySearchTree<T>::rotateLeftChild(TNode<T>*& p) {
	TNode<T>* following = p->left;
	p->left = following->right;
	following->right = p;
	p->height = max(height(p->left), height(p->right)) + 1;
	following->height = max(height(following->left), p->height) + 1;
	p = following;
}

template <typename T>
void BalanceBinarySearchTree<T>::rotateRightChild(TNode<T>*& p) {
	TNode<T>* following = p->right;
	p->right = following->left;
	following->left = p;
	p->height = max(height(p->left), height(p->right)) + 1;
	following->height = max(height(following->right), p->height) + 1;
	p = following;
}

template <typename T>
void BalanceBinarySearchTree<T>::doubleLeftChild(TNode<T>*& p) {
	rotateRightChild(p->left);
	rotateLeftChild(p);
}

template <typename T>
void BalanceBinarySearchTree<T>::doubleRightChild(TNode<T>*& p) {
	rotateLeftChild(p->right);
	rotateRightChild(p);
}

//additional metods
//1printSorted
template<typename T>
void BalanceBinarySearchTree<T>::printSorted() {
	cout << "\n\nAscending order: \n";
	printSorted_ascen(BinaryTree<T>::root);
	cout << "\nDescending order: \n";
	printSorted_descen(BinaryTree<T>::root);
}

template<typename T>
void BalanceBinarySearchTree<T>::printSorted_ascen(TNode<T>* p) {
	if (p != NULL) {
		printSorted_ascen(p->left);
		cout << p->data << ", ";
		printSorted_ascen(p->right);
	}
}

template<typename T>
void BalanceBinarySearchTree<T>::printSorted_descen(TNode<T>* p) {
	if (p != NULL) {
		printSorted_descen(p->right);
		cout << p->data << ", ";
		printSorted_descen(p->left);
	}
}

//2сountNode
template<typename T>
int BalanceBinarySearchTree<T>::countNode() {
	int sum = 0;
	if (BinaryTree<int>::root == NULL) return sum;
	countNode_rec(BinaryTree<int>::root, sum);
	return sum;
}

template<typename T>
void BalanceBinarySearchTree<T>::countNode_rec(TNode<T>* p, int& sum) {
	if (p->left != NULL) {
		++sum;
		countNode_rec(p->left, sum);
	}
	if (p->right != NULL) countNode_rec(p->right, sum);
}

//3sumKeys
template<>
int BalanceBinarySearchTree<int>::sumKeys() {
	int sum = 0;
	if (BinaryTree<int>::root == NULL) return sum;
	sumKeys_rec(BinaryTree<int>::root, sum);
	return sum;
}

template<>
void BalanceBinarySearchTree<int>::sumKeys_rec(TNode<int>* p, int& sum) {
	if (p->right != NULL) {
		sum += p->right->data;
		sumKeys_rec(p->right, sum);
	}
	if (p->left != NULL) sumKeys_rec(p->left, sum);
}

//4deleteEven
template<>
void BalanceBinarySearchTree<int>::deleteEven() {
	deleteEven_rec(BinaryTree<int>::root);
}

template<>
void BalanceBinarySearchTree<int>::deleteEven_rec(TNode<int>* p) {
	if (p != NULL) {
		if (p->data % 2 == 0) {
			deleteNode(p->data);
			p = BinaryTree<int>::root;
			deleteEven_rec(p);
		}
		deleteEven_rec(p->right);
		deleteEven_rec(p->left);
	}
}

//5findMiddle
template<>
int BalanceBinarySearchTree<int>::findMiddle() {
	int mid = (findMax(BinaryTree<int>::root) + findMin(BinaryTree<int>::root)) / 2;
	if (search(mid)) return mid;
	int n = abs(BinaryTree<int>::root->data - mid);
	int node = BinaryTree<int>::root->data;
	findMiddle_rec(BinaryTree<int>::root, mid, n, node);
	return node;
}

template<>
int BalanceBinarySearchTree<int>::findMax(TNode<int>* p) {
	while (p->right != NULL) p = p->right;
	return p->data;
}

template<>
int BalanceBinarySearchTree<int>::findMin(TNode<int>* p) {
	while (p->left != NULL) p = p->left;
	return p->data;
}

template<>
void BalanceBinarySearchTree<int>::findMiddle_rec(TNode<int>* p, int mid, int n, int& node) {
	if (p == NULL) return;
	else if (p->data > mid) {
		if (abs(p->data - mid) < n) {
			n = abs(p->data - mid);
			node = p->data;
		}
		findMiddle_rec(p->left, mid, n, node);
	}
	else {
		if (abs(p->data - mid) < n) {
			n = abs(p->data - mid);
			node = p->data;
		}
		findMiddle_rec(p->right, mid, n, node);
	}
}

//6findSecondLargest()
template<>
int BalanceBinarySearchTree<int>::findSecondLargest() {
	if (BinaryTree<int>::size_rec(BinaryTree<int>::root) == 2 && BinaryTree<int>::root->right == NULL) return BinaryTree<int>::root->left->data;
	else if (BinaryTree<int>::root != NULL) {
		int max_node = findMax(BinaryTree<int>::root);
		return findSecondLargest_rec(BinaryTree<int>::root, max_node)->data;
	}
	else {
		cout << "\n\nTree is empty\n";
		return -10000;
	}
}

template<>
TNode<int>* BalanceBinarySearchTree<int>::findSecondLargest_rec(TNode<int>* p, int max_node) {
	if (p->right->data == max_node) return p;
	return findSecondLargest_rec(p->right, max_node);
}

//7copyBBST
template<typename T>
BalanceBinarySearchTree<T> BalanceBinarySearchTree<T>::copyBBST() {
	BalanceBinarySearchTree<T> copy;
	copyBBST_rec(BalanceBinarySearchTree<T>::root, copy);
	return copy;
}

template<typename T>
void BalanceBinarySearchTree<T>::copyBBST_rec(TNode<T>* p, BalanceBinarySearchTree<T>& copy) {
	if (p != NULL) {
		copy.addcopy(p->data);
		copyBBST_rec(p->right, copy);
		copyBBST_rec(p->left, copy);
	}
}

template <typename T>
void BalanceBinarySearchTree<T>::addcopy(int item) {
	if (search(item)) cout << endl << item << " is dublicate;\n";
	else BinaryTree<T>::root = addcopy_rec(item, BinaryTree<T>::root);
}

template <typename T>
TNode<T>* BalanceBinarySearchTree<T>::addcopy_rec(int item, TNode<T>* p) {
	if (p == NULL) p = new TNode<T>(item);
	else if (item < p->data) p->left = addcopy_rec(item, p->left);
	else p->right = addcopy_rec(item, p->right);
	if (height(p->left) > height(p->right)) p->height = height(p->left) + 1;
	else p->height = height(p->right) + 1;
	return p;
}

//8insertBBST
template<typename T>
void BalanceBinarySearchTree<T>::insertBBST(BalanceBinarySearchTree<T>B) {
	insertBBST_rec(B.root);
}

template<typename T>
void BalanceBinarySearchTree<T>::insertBBST_rec(TNode<T>* p) {
	if (p != NULL) {
		addNode(p->data);
		insertBBST_rec(p->right);
		insertBBST_rec(p->left);
	}
}


int main()
{
   
}