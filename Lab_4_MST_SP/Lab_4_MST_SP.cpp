#include <iostream>

using namespace std;

struct edge{

	int vertex1; //data members
	int vertex2;
	int weight;
	edge* next; //link member

	edge(int v1, int v2, int w) //constructor
	{
		vertex1 = v1;
		vertex2 = v2;
		weight = w;
		next = NULL;
	}
};

class Graph
{
public:
	Graph();
	~Graph();
	int Nodes_number();
	int Edges_number();

private:
	int n; // number of vertices
	int m; // number of edges in graph or digraph
	edge* adjacencyList; //pointer to array of pointers to adjacency lists
	void Print_list(int);
};

int main()
{
    
}
