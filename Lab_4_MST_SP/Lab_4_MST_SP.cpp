#include <iostream>
#include <math.h>

using namespace std;

struct edge{

	int vertex1; //data members
	int vertex2;
	int weight;
	edge* next; //link member

	edge() {
		vertex1 = 0;
		vertex2 = 0;
		weight = 0;
		next = NULL;
	}
	edge(int v1, int v2, int w) //constructor
	{
		vertex1 = v1;
		vertex2 = v2;
		weight = w;
		next = NULL;
	}
};

typedef edge* p_edge;
typedef int* p_int;

//A Graph object is created via dialog with a user.
//The object is represented by linked adjacency lists unsorted by numbers of vertices.
class Graph{

public:
	Graph();
	~Graph();
	int Vertices_number() { return n; };
	int Edges_number() { return m; };
	void Print_graph();
	void Prim(int);
	void Kruskal();

private:

	int n; // number of vertices
	int m; // number of edges in graph or digraph

	p_edge* adjacencyList; //pointer to array of pointers to adjacency lists
	void Insert(int, int, int);
	bool Search(int, int);
	void Print_list(int);
	void Insert_fringe_sort(p_edge&, int, int, int);
	void Heapsort(p_edge L[], int);
	void SettleRoot(p_edge L[], int, int);
	void Swap(int item1, int item2, p_edge L[]);
};

//Constructor

Graph::Graph(){ 

	int edge_weight, answer = 1; //to read numbers of adjacent vertices
	int edge_count = 0;

	cout << "Enter number of graph vertices ==> ";
	cin >> n;

	//A dynamic array of pointers to linked adjacency lists is created and initialized.
	adjacencyList = new p_edge[n + 1];
	for (int i = 1; i <= n; ++i) adjacencyList[i] = NULL;

	for (int i = 1; i <= n; ++i, answer = 1){ //Adjacency linked lists for an input graph are created.
		cout << " \nADJACENCY LIST for graph VERTEX #" << i << endl;
		while (answer != -1){
			cout << "Enter number of current adjacent vertex (-1 to finish) ==> ";
			cin >> answer;

			if (answer == -1) break;
			else if (answer >= 1 && answer <= n){
				cout << "Enter integer weight of edge " << i << "--" << answer << " ==> ";
				cin >> edge_weight;
				if (Search(i, answer)) continue;
				Insert(i, answer, edge_weight);
				if(i != answer)Insert(answer, i, edge_weight);
				edge_count++;
			}
			else cout << "VERTEX NUMBER IS OUT OF RANGE!!\n";
		}
	}
	m = edge_count;

	cout << "\nADJACENCY LISTS for each vertex of input graph:\n";
	for (int i = 1; i <= n; ++i){
		cout << "List for vertex #" << i << ": ";
		Print_list(i);
	}
}

//Destructor

Graph::~Graph(){

	for (int i = 1; i <= n; i++){
		p_edge temp;

		while (adjacencyList[i] != NULL){
			temp = adjacencyList[i];
			adjacencyList[i] = adjacencyList[i]->next;
			delete temp;
		}
	}
}

// Metods of class

void Graph::Insert(int father_ver, int son_ver, int w){

	p_edge new_pointer = new edge(father_ver, son_ver, w);;

	new_pointer->next = adjacencyList[father_ver];
	adjacencyList[father_ver] = new_pointer;
}

bool Graph::Search(int father_ver, int son_ver) {

	for (p_edge current = adjacencyList[father_ver]; current != NULL; current = current->next)
		if (current->vertex2 == son_ver) return true;
	return false;
}

void Graph::Print_list(int father_ver) {
	
	p_edge current = adjacencyList[father_ver];

	while (current != NULL){
		cout << '(' << father_ver << "--" << current->vertex2 << '|' << current->weight << ')' << ", ";
		current = current->next;
	}
	
	cout << endl;
}

void Graph::Print_graph() {

	cout << "\nMatrix: \n\n";
	for (int i = 0; i < n + 1; ++i) {
		p_edge current = adjacencyList[i];
		for (int j = 0; j < n + 1; ++j) {
			if ((i == 0 || j == 0)) cout << "V" << max(i, j) << "\t";
			else { 
				if (!(Search(i, j))) cout << 0 << "\t";
				else {
					for (p_edge current = adjacencyList[i]; current != NULL; current = current->next)
						if (current->vertex2 == j) cout << current->weight << "\t";
				}
			}
		}
		cout << "\n\n";
	}
}

void Graph::Kruskal(){ //It finds MST in a weighted, undirected, connected graph with no loops and multiple edges.

	p_edge current;
	int MST_count = 1, count = 0;
	p_edge* edge_list = new p_edge[m + 1]; //array for graph edges
	p_edge* MST_edges = new p_edge[n]; //array for MST edges
	p_int component = new int[n + 1]; //array to register connected components of vertices
	for (int i = 1; i <= n; ++i) component[i] = i; //Initially each vertex is treated as a separate component #i.

	for (int i = 1; i <= n; ++i){
		current = adjacencyList[i];
		while (current != NULL){
			if (current->vertex2 > i) edge_list[++count] = current;
			current = current->next;
		}
	}

	Heapsort(edge_list, count);

	// SELECTING AND INCLUDING EDGES INTO MST
	for (int i = 1; i <= count && MST_count < n; ++i){

		int a = edge_list[i]->vertex1;
		int b = edge_list[i]->vertex2;

		if (component[a] != component[b]){ //both vertices belong to different connected components

			MST_edges[MST_count] = edge_list[i];
			MST_count++;
			//updating the list of connected components
			int keep = component[b];
			for (int j = 1; j <= n; ++j) if (component[j] == keep) component[j] = component[a];
		}
	}

	delete[]component;
	delete[]edge_list;

	// PRINTING MST
	cout << " \nLIST of EDGES in MST_Kruskal: \n";
	for (int i = 1; i < n; ++i)
		cout << MST_edges[i]->vertex1 << ',' << MST_edges[i]->vertex2 << " edge weight: " << MST_edges[i]->weight << endl;
	
	delete[]MST_edges;
}

void Graph::Heapsort(p_edge L[], int n){
	for (int i = n / 2; i >= 1; --i) 
		SettleRoot(L, i, n);

	for (int end = n - 1; end >= 1; --end){	
		Swap(1, end + 1, L);
		SettleRoot(L, 1, end);
	}
}

void Graph::SettleRoot(p_edge L[], int root, int last){

	int child, unsettled = root;
	while (2 * unsettled <= last){

		if (2 * unsettled < last && L[2 * unsettled + 1]->weight > L[2 * unsettled]->weight)
			child = 2 * unsettled + 1;	
		else child = 2 * unsettled;		

		if (L[unsettled]->weight < L[child]->weight){
			Swap(unsettled, child, L);
			unsettled = child;
		}
		else break;
	}
}

void Graph::Swap(int item1, int item2, p_edge L[]) {
	p_edge temp = L[item1];
	L[item1] = L[item2];
	L[item2] = temp;
}

//Additional metod #7

void Graph::Prim(int start_vertex){

	int father, son, w;
	p_edge current = adjacencyList[start_vertex], fringe_pointer = NULL; // pointer to a linked list of fringe edges
	
	p_int* MST = new p_int[n+1]; //MST array
	for (int i = 0; i <= n; ++i) {
		MST[i] = new int[n+1];
		for (int j = 0; j <= n; ++j) MST[i][j] = 0;
	}

	//array to register status of vertices: 'u'-unseen, 'f'-fringe, 't'- in MST
	char* marks_status = new char[n + 1];
	for (int i = 1; i <= n; i++) marks_status[i] = 'u';

	// PROCESSING START VERTEX
	marks_status[start_vertex] = 't'; //include start_vertex into MST
	
	while (current != NULL){ //creating fringe for start_vertex
		father = current->vertex1;
		son = current->vertex2;
		w = current->weight;

		if (father != son) {
			Insert_fringe_sort(fringe_pointer, father, son, w);
			marks_status[son] = 'f';
		}

		current = current->next;
	}

	// PROCESSING OTHER VERTICES
	while (fringe_pointer != NULL){

		p_edge new_MST_edge = fringe_pointer; //pointer to 1st fringe edge
		fringe_pointer = fringe_pointer->next; //excluding min edge from fringe
		// including min weight edge into linked list of MST edges at the beginning
		MST[new_MST_edge->vertex1][new_MST_edge->vertex2] = new_MST_edge->weight;
		MST[new_MST_edge->vertex2][new_MST_edge->vertex1] = new_MST_edge->weight;

		marks_status[new_MST_edge->vertex2] = 't';
		//updating the fringe for new vertex included in MST
		current = adjacencyList[new_MST_edge->vertex2];
		while (current != NULL)
		{
			if (marks_status[current->vertex2] != 't')
			{
				father = current->vertex1;
				son = current->vertex2;
				w = current->weight;
				//updating fringe linked list, excluding duplicate edges
				if (father != son) {
					Insert_fringe_sort(fringe_pointer, father, son, w);
					marks_status[son] = 'f';
				}
			}
			current = current->next;
		}
	}
	delete[] marks_status;

	// PRINTING MST
	cout << " \nLIST of EDGES in Prim's MST: \n\n";
	for (int i = 0; i < n + 1; ++i) {
		for (int j = 0; j < n + 1; ++j) {
			if ((i == 0 || j == 0)) cout << "V" << max(i,j) << "\t";
			else {
				if (MST[i][j] != 0) cout << MST[i][j] << "\t";
				else cout << 0 << "\t";
			}
		}
		cout << "\n\n";
	}
}

//List is a reference to a pointer to a linked fringe list of candidate edges.
//List nodes are sorted by weights of edges.

void Graph::Insert_fringe_sort(p_edge& List, int father_ver, int son_ver, int w){
	
	p_edge ptr, //pointer to new edge
	previous = NULL, current = List; 
	int insert_search = 0; //mode of inserting a new node into the list
	
// Possible values of insert_search:
//0 - do nothing;
//1 - insert a new edge into a fringe linked list;
// 2 - insert a new edge into a list + search & delete a possible second candidate edge.

	//The position is found to insert a new edge into the fringe linked list.
	while (current != NULL && current->weight < w && current->vertex2 != son_ver)
	{
		previous = current;
		current = current->next;
	}

	if (current == NULL) insert_search = 1; //Add the edge without search for a duplicate edge.
	else if (current->weight >= w) insert_search = 2; //Add the edge and search for a duplicate edge.

	if (insert_search != 0){

		ptr = new edge(father_ver, son_ver, w);

		if (previous == NULL){ //The new list node is added at the beginning of the linked list.
			ptr->next = List;
			List = previous = ptr;
		}
		else{ 
			ptr->next = current;
			previous->next = ptr;
			previous = ptr;
		}

		if (insert_search == 2){ //A possible duplicate candidate edge is searched for.
			
			while (current != NULL && current->vertex2 != son_ver){
				previous = current;
				current = current->next;
			}

			if (current != NULL){ //A duplicate candidate edge is deleted.
				previous->next = current->next;
				delete current;
			}
		}
	}
}

int main()
{
	Graph MyGraph;
	MyGraph.Print_graph();
	MyGraph.Kruskal();
}
