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

private:

	int n; // number of vertices
	int m; // number of edges in graph or digraph

	p_edge* adjacencyList; //pointer to array of pointers to adjacency lists
	void Insert(int, int, int);
	bool Search(int, int);
	void Print_list(int);
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

//Additional metod #7

void Graph::Prim(int start_vertex){

	int father, son, weight;
	p_edge current = adjacencyList[start_vertex], fringe_pointer = NULL; // pointer to a linked list of fringe edges
	
	p_int* MST = new p_int[n]; //MST array
	for (int i = 0; i < n; ++i) {
		MST[i] = new int[n];
		for (int j = 0; j < n; ++j) MST[i][j] = 0;
	}

	//array to register status of vertices: 'u'-unseen, 'f'-fringe, 't'- in MST
	char* marks_status = new char[n + 1];
	for (int i = 1; i <= n; i++) marks_status[i] = 'u';

	// PROCESSING START VERTEX
	marks_status[start_vertex] = 't'; //include start_vertex into MST
	
	while (current != NULL){ //creating fringe for start_vertex
		father = current->vertex1;
		son = current->vertex2;
		weight = current->weight;

		if (father != son) {
			//insert fringe edge
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

		marks_status[new_MST_edge->vertex2] = 't';
		//updating the fringe for new vertex included in MST
		current = adjacencyList[new_MST_edge->vertex2];
		while (current != NULL)
		{
			if (marks_status[current->vertex2] != 't')
			{
				father = current->vertex1;
				son = current->vertex2;
				weight = current->weight;
				//updating fringe linked list, excluding duplicate edges
				if (father != son) {
					//insert fringe edge
					marks_status[son] = 'f';
				}
			}
			current = current->next;
		}
	}
	delete[] marks_status;

	// PRINTING MST
	cout << " \nLIST of EDGES in Prim's MST: \n";
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

int main()
{
	Graph MyGraph;
	MyGraph.Print_graph();
}
