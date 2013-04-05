using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquila.Data
{
    class Deck<T> : IEnumerable<T>
    {
        /// <summary>
        /// If the deck should shuffle and add the discard pile if the deck is empty
        /// </summary>
        public bool AutoShuffle { get; set; }

        /// <summary>
        /// Wether the deck is empty (no cards can be drawn)
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                if (active.Count > 0)
                    return false;
                if (AutoShuffle && discard.Count > 0)
                    return false;
                return true;
            }
        }

        protected Queue<T> active;
        protected List<T> discard;

        /// <summary>
        /// Creates a new empty deck
        /// </summary>
        public Deck()
        {
            active = new Queue<T>();
            discard = new List<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (!IsEmpty)
                yield return Draw();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        /// <summary>
        /// Draw a card from the deck
        /// </summary>
        /// <returns>The drawn card</returns>
        public T Draw()
        {
            if (active.Count == 0)
            {
                if (!AutoShuffle || discard.Count == 0)
                    return default(T);

                Shuffle();
            }

            return active.Dequeue();
        }

        /// <summary>
        /// Put a card on the discard pile
        /// </summary>
        /// <param name="card"></param>
        public void Discard(T card)
        {
            discard.Add(card);
        }

        /// <summary>
        /// Add a card to the bottom of the deck
        /// </summary>
        /// <param name="card">The card to add</param>
        public void Add(T card)
        {
            active.Enqueue(card);
        }

        /// <summary>
        /// Shuffles all cards in the active and discard pile
        /// </summary>
        public void Shuffle()
        {
            while (active.Count > 0)
                discard.Add(active.Dequeue());

            var r = new Random();

            foreach(T card in discard.OrderBy((a) => r.Next()))
                active.Enqueue(card);

            discard.Clear();
        }
    }
}
