using System;
using System.Collections.Generic;
using System.Linq;

namespace IterativeLayoutAlgorithm
{
    public class IterativeLayout
    {
        public static void FormSubmatrices(int[,] adjacencyMatrix, out List<int> firstPartOfGraph,
            out List<int> secondPartOfGraph, int group)
        {
            firstPartOfGraph = new List<int>(Enumerable.Range(0, group));

            int secondGroup = firstPartOfGraph[firstPartOfGraph.Count - 1] + 1;

            secondPartOfGraph = new List<int>(Enumerable.Range(secondGroup, adjacencyMatrix.GetLength(0) - group));
        }

        public static int[] CalculateVertexConnectivityCoefficient(int[,] adjacencyMatrix, List<int> firstPartOfGraph,
            List<int> secondPartOfGraph)
        {
            int[] arrayOfVertexConnectivityCoefficients = new int[adjacencyMatrix.GetLength(0)];

            for (int i = 0; i < arrayOfVertexConnectivityCoefficients.Length; i++)
            {
                arrayOfVertexConnectivityCoefficients[i] = 0;

                if (i <= firstPartOfGraph[firstPartOfGraph.Count - 1])
                {
                    for (int j = arrayOfVertexConnectivityCoefficients.Length - 1; j >= 0; j--)
                    {
                        if (j > firstPartOfGraph[firstPartOfGraph.Count - 1])
                        {
                            arrayOfVertexConnectivityCoefficients[i] += adjacencyMatrix[i, j];
                        }
                        else
                        {
                            arrayOfVertexConnectivityCoefficients[i] -= adjacencyMatrix[i, j];
                        }
                    }
                }
                else
                {
                    for (int j = arrayOfVertexConnectivityCoefficients.Length - 1; j >= 0; j--)
                    {
                        if (j < secondPartOfGraph[0])
                        {
                            arrayOfVertexConnectivityCoefficients[i] += adjacencyMatrix[i, j];
                        }
                        else
                        {
                            arrayOfVertexConnectivityCoefficients[i] -= adjacencyMatrix[i, j];
                        }
                    }
                }
            }

            return arrayOfVertexConnectivityCoefficients;
        }

        private static int[,] FormPermutationMatrix(int[,] adjacencyMatrix, List<int> firstPartOfGraph,
            List<int> secondPartOfGraph)
        {
            int[,] permutationMatrix = new int[firstPartOfGraph.Count, secondPartOfGraph.Count];
            int[] arrayOfVertexConnectivityCoefficients =
                CalculateVertexConnectivityCoefficient(adjacencyMatrix, firstPartOfGraph, secondPartOfGraph);

            for (int i = 0; i < firstPartOfGraph.Count; i++)
            {
                for (int j = 0; j < secondPartOfGraph.Count; j++)
                {
                    permutationMatrix[i, j] = arrayOfVertexConnectivityCoefficients[firstPartOfGraph[i]] +
                        arrayOfVertexConnectivityCoefficients[secondPartOfGraph[j]] -
                        2 * adjacencyMatrix[firstPartOfGraph[i], secondPartOfGraph[j]];
                }
            }

            return permutationMatrix;
        }

        private static int[] PermutationOfAdjacencyMatrixElements(ref int[,] adjacencyMatrix,
            List<int> firstPartOfGraph, List<int> secondPartOfGraph)
        {
            int[,] permutationMatrix = FormPermutationMatrix(adjacencyMatrix, firstPartOfGraph, secondPartOfGraph);

            const int sizeOfPermutationIndicesArray = 2;
            int[] arrayOfPermutationIndices = new int[sizeOfPermutationIndicesArray];

            int maxValue = permutationMatrix.Cast<int>().Max();
            int indexI = -1;
            int indexJ = -1;

            for (int i = 0; i < permutationMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < permutationMatrix.GetLength(1); j++)
                {
                    if (permutationMatrix[i, j] == maxValue)
                    {
                        indexI = firstPartOfGraph[i];
                        indexJ = secondPartOfGraph[j];
                    }
                }
            }

            arrayOfPermutationIndices[0] = indexI;
            arrayOfPermutationIndices[1] = indexJ;

            for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
            {
                int temporaryVariable = adjacencyMatrix[i, indexJ];
                adjacencyMatrix[i, indexJ] = adjacencyMatrix[i, indexI];
                adjacencyMatrix[i, indexI] = temporaryVariable;
            }
            for (int j = 0; j < adjacencyMatrix.GetLength(1); j++)
            {
                int temporaryVariable = adjacencyMatrix[indexJ, j];
                adjacencyMatrix[indexJ, j] = adjacencyMatrix[indexI, j];
                adjacencyMatrix[indexI, j] = temporaryVariable;
            }

            return arrayOfPermutationIndices;
        }

        private static int[,] DeleteElementsFromAdjacencyMatrix(int[,] adjacencyMatrix,
            List<int> secondPartOfGraph)
        {
            int[,] newAdjacencyMatrix = new int[secondPartOfGraph.Count, secondPartOfGraph.Count];

            for (int i = 0; i < newAdjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < newAdjacencyMatrix.GetLength(1); j++)
                {
                    newAdjacencyMatrix[i, j] = adjacencyMatrix[secondPartOfGraph[i], secondPartOfGraph[j]];
                }
            }

            return newAdjacencyMatrix;
        }

        public static int[][] StartLayout(int[,] adjacencyMatrix, int[] numberOfGroups)
        {
            bool isExit;

            int[][] arrayOfLayoutGroups = new int[numberOfGroups.Length][];

            int zeroVariable = 0;

            for (int i = 0; i < numberOfGroups.Length; i++)
            {
                arrayOfLayoutGroups[i] = new int[numberOfGroups[i]];
            }

            for (int i = 0; i < arrayOfLayoutGroups.GetLength(0); i++)
            {
                for (int j = 0; j < arrayOfLayoutGroups[i].Length; j++)
                {
                    arrayOfLayoutGroups[i][j] = zeroVariable;
                    zeroVariable++;
                }
            }

            for (int h = 0; h < numberOfGroups.Length - 1; h++)
            {
                FormSubmatrices(adjacencyMatrix, out var firstPartOfGraph, out var secondPartOfGraph, numberOfGroups[h]);

                int[] arrayOfVertexConnectivityCoefficients =
                    CalculateVertexConnectivityCoefficient(adjacencyMatrix, firstPartOfGraph, secondPartOfGraph);

                do
                {
                    isExit = true;

                    var tempMatrix = FormPermutationMatrix(adjacencyMatrix, firstPartOfGraph, secondPartOfGraph);

                    for (int i = 0; i < arrayOfVertexConnectivityCoefficients.Length; i++)
                    {
                        if (arrayOfVertexConnectivityCoefficients[i] > 0)
                        {
                            isExit = false;
                        }
                    }

                    if (!isExit)
                    {
                        isExit = true;

                        for (int i = 0; i < tempMatrix.GetLength(0); i++)
                        {
                            for (int j = 0; j < tempMatrix.GetLength(1); j++)
                            {
                                if (tempMatrix[i, j] > 0)
                                    isExit = false;
                            }
                        }
                    }

                    if (!isExit)
                    {
                        var permutationMatrix =
                            PermutationOfAdjacencyMatrixElements(ref adjacencyMatrix, firstPartOfGraph, secondPartOfGraph);

                        int indexI = -1;
                        int indexJ = -1;
                        zeroVariable = firstPartOfGraph.Count;

                        for (int i = h + 1; i < arrayOfLayoutGroups.GetLength(0); i++)
                        {
                            if (arrayOfLayoutGroups[i].Length > permutationMatrix[1] - zeroVariable)
                            {
                                indexI = i;
                                indexJ = permutationMatrix[1] - zeroVariable;
                                break;
                            }
                            else
                            {
                                zeroVariable += arrayOfLayoutGroups[i].Length;
                            }
                        }

                        int temporaryVariable = arrayOfLayoutGroups[indexI][indexJ];
                        arrayOfLayoutGroups[indexI][indexJ] = arrayOfLayoutGroups[h][permutationMatrix[0]];
                        arrayOfLayoutGroups[h][permutationMatrix[0]] = temporaryVariable;

                        arrayOfVertexConnectivityCoefficients =
                            CalculateVertexConnectivityCoefficient(adjacencyMatrix, firstPartOfGraph, secondPartOfGraph);
                    }
                }
                while (!isExit);

                adjacencyMatrix = DeleteElementsFromAdjacencyMatrix(adjacencyMatrix, secondPartOfGraph);
            }

            return arrayOfLayoutGroups;
        }

        public static int[,] IterativeLayoutGraph(int[,] adjacencyMatrix, int[][] groups)
        {
            int[,] arrayResult = adjacencyMatrix.Clone() as int[,];

            int k = 0;

            for (int i = 0; i < groups.GetLength(0); i++)
            {
                for (int j = 0; j < groups[i].Length; j++)
                {
                    for (int h = 0; h < adjacencyMatrix.GetLength(0); h++)
                    {
                        int temp = arrayResult[h, groups[i][j]];
                        arrayResult[h, groups[i][j]] = arrayResult[h, k];
                        arrayResult[h, k] = temp;
                    }
                    for (int h = 0; h < adjacencyMatrix.GetLength(1); h++)
                    {
                        int temp = arrayResult[groups[i][j], h];
                        arrayResult[groups[i][j], h] = arrayResult[k, h];
                        arrayResult[k, h] = temp;
                    }

                    k++;
                }
            }

            return arrayResult;
        }
    }
}
