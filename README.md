# Dijkstra Algorithm - Shortest Path Finder

This project demonstrates the implementation of **Dijkstra’s algorithm** to calculate the shortest path between nodes in a weighted graph using C#. It also includes a comparison of different potential routes to determine the most efficient one.

---

## 🧠 About the Algorithm

Dijkstra’s algorithm is a classic solution for finding the shortest path from a single source node to all other nodes in a weighted graph with non-negative edge weights. This project goes a step further by:

- Calculating multiple path variants.
- Comparing total path weights.
- Showing how direction and edge costs affect the optimality of paths.

---

## 🧾 Features

- Custom graph structure using a 2D array.
- Pathfinding between any two nodes.
- Calculates edge weights based on Euclidean distance (`Cd(x, y)`).
- Compares alternate routes between start and end nodes.
- Displays formatted paths and total weights.

---

## 🔧 Code Structure

### 📁 Main Class

- `DijkstraAlgorithm.Dijkstra` contains:
  - `DijkstraAlgorithm()`: Core pathfinding logic.
  - `PrintPath()`: Utility to format and calculate path weights.
  - `Cd(int y, int x)`: Helper for calculating edge weights using coordinate differences.
  - A `Main()` method that demonstrates several route evaluations.

### 🔢 Graph Representation

- The graph is represented as a **2D adjacency matrix**, where:
  - Each cell `[i, j]` holds the weight of the edge between node i and node j.
  - `Cd(y, x)` calculates this weight dynamically.

---

## 🚀 How to Run

1. Clone or download the repository.
2. Open the project in Visual Studio or another C# IDE.
3. Build and run the solution.
4. The console will print:
   - The shortest paths.
   - Total weights.
   - Comparative path analysis.

---

## 📌 Example Output

```plaintext
Shortest path A-B
1->3->5->7->9
Total weight is: 13.56

Shortest path A-D-C-B
1->4->6->9
Total weight is: 10.83

Shortest path A-C-D-B
1->6->7->9
Total weight is: 14.01

Path A-D-C-B is shorter than path A-C-D-B
