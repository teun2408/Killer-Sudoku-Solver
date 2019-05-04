﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace KillerSudokuSolver
{
    public static class Cloner
    {
        /// <summary>
        /// Perform a deep Copy of the object using a BinaryFormatter.
        /// IMPORTANT: the object class must be marked as [Serializable] and have an parameterless constructor.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new MemoryStream())
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static KillerSudoku Clone2(this KillerSudoku source)
        {
            Board cloneBoard = new Board(null, source.board.logger);
            List<Cage> clonedCages = new List<Cage>();
            for (int i = 0; i < source.board.board.Count; i++)
            {
                List<Field> newRow = new List<Field>();
                source.board.board[i].ForEach(field =>
                {
                    newRow.Add(new Field(field.coordinates, field.value, true));
                });
                cloneBoard.board[i] = newRow;
            }

            source.cages.ForEach(cage =>
            {
                clonedCages.Add(new Cage(cage.coordinates, cage.combinedValue, true));
            });
            return new KillerSudoku(clonedCages, cloneBoard);
        }
    }
}
