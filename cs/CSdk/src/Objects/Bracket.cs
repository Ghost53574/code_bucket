using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace CSDK {
    namespace Objects  {
        [Serializable]
        public class Bracket {
            private Vertex x, y, z, a, b, c, l, m, n, r, t, o;
            private Dictionary<Direction.Edges, HashSet<Point[]>> _edges;
            private Dictionary<Direction.Faces, HashSet<Vertex[]>> _faces;
            private List<KeyValuePair<Direction.Faces, Vertex[]>> _Faces = new List<KeyValuePair<Direction.Faces, Vertex[]>>();
            private List<KeyValuePair<Direction.Edges, Point[]>> _Edges = new List<KeyValuePair<Direction.Edges, Point[]>>();

            /* * * * * * * * * * * * * * * * *
             * Get distance (c) by a^2 + b^2 = c^2
             * Set angles by x (sin) : y (cos) : z (tan)
             * Set rotation of right angle, triangle (xyz)
             * Set depth by variant of z and angle */
            private void FindEdges()
            {
                HashSet<Vertex[]> edges = new HashSet<Vertex[]>();
                HashSet<Vertex[]>.Enumerator itt = edges.GetEnumerator();

                do
                {
                    //Temp
                } while (itt.MoveNext());

                topedges = new HashSet<Vertex>();
                inneredges = new HashSet<Vertex>();

                int i = 0, k = 0, j = 0, blob_size = blob.Length;

                Line[] matrix = new Line[blob_size];
                Line max = null;
                for (; i < blob_size; ++i)
                {
                    if ((max != null) && max > matrix[i])
                        continue;
                    max = matrix[i];
                }

                int i = 0;
                Point[] matrix = new Point[blob.Length];
                i = 0;
                Point distance = null, edge;
                do
                {
                    Line line = blob[i].Value;
                    matrix[i] = blob[i].GetOrientation();
                    if (distance != null)
                    {
                        int k = blob.Length - i;
                        int j = 0;
                        Point max = null;
                        for (k = blob.Length; k > j; --k)
                        {
                            if ((max != null) && max > matrix[k])
                                continue;
                            max = matrix[k];
                        }
                        for (; j < blob.Length; ++j)
                        {
                            Point vertex = matrix[j];
                            edge = distance;
                            for (k = 0; k > j; --k)
                            {

                            }
                            for (k = 0; k < j; ++k)
                            {

                            }
                        }
                    }
                    distance = blob[i].Value[0] - blob[i].Value[1];
                } while (blob[i++].GetOrientation() != matrix[blob.Length - 1]);
            }

            public Bracket () {
                x = new Vertex ();
                y = new Vertex ();
            }

            public Bracket (Vertex x, Vertex y) {
                this.x = x;
                this.y = y;
            }

            public Bracket (Vertex x, Vertex y, Vertex z) {
                this.x = x;
                this.y = y;
                this.z = z;
            }

            public Bracket (Vertex x, Vertex y, Vertex z, Vertex a) {
                this.x = x;
                this.y = y;
                this.z = z;
                this.a = a;
            }

            public Bracket (Vertex x, Vertex y, Vertex z, Vertex a, Vertex b) {
                this.x = x;
                this.y = y;
                this.z = z;
                this.a = a;
                this.b = b;
            }

            public Bracket (Vertex x, Vertex y, Vertex z, Vertex a, Vertex b, Vertex c) {
                this.x = x;
                this.y = y;
                this.z = z;
                this.a = a;
                this.b = b;
                this.c = c;
            }

            public Bracket (Vertex x, Vertex y, Vertex z, Vertex a, Vertex b, Vertex c, Vertex l) {
                this.x = x;
                this.y = y;
                this.z = z;
                this.a = a;
                this.b = b;
                this.c = c;
                this.l = l;
            }

            public Bracket (Vertex x, Vertex y, Vertex z, Vertex a, Vertex b, Vertex c, Vertex l, Vertex m) {
                this.x = x;
                this.y = y;
                this.z = z;
                this.a = a;
                this.b = b;
                this.c = c;
                this.l = l;
                this.m = m;
            }

            public Bracket (Vertex x, Vertex y, Vertex z, Vertex a, Vertex b, Vertex c, Vertex l, Vertex m, Vertex n) {
                this.x = x;
                this.y = y;
                this.z = z;
                this.a = a;
                this.b = b;
                this.c = c;
                this.l = l;
                this.m = m;
                this.n = n;
            }

            public Bracket (Vertex x, Vertex y, Vertex z, Vertex a, Vertex b, Vertex c, Vertex l, Vertex m, Vertex n, Vertex r) {
                this.x = x;
                this.y = y;
                this.z = z;
                this.a = a;
                this.b = b;
                this.c = c;
                this.l = l;
                this.m = m;
                this.n = n;
                this.r = r;
            }

            public Bracket (Vertex x, Vertex y, Vertex z, Vertex a, Vertex b, Vertex c, Vertex l, Vertex m, Vertex n, Vertex r, Vertex t) {
                this.x = x;
                this.y = y;
                this.z = z;
                this.a = a;
                this.b = b;
                this.c = c;
                this.l = l;
                this.m = m;
                this.n = n;
                this.r = r;
                this.t = t;
            }

            public Bracket (Vertex x, Vertex y, Vertex z, Vertex a, Vertex b, Vertex c, Vertex l, Vertex m, Vertex n, Vertex r, Vertex t, Vertex o) {
                this.x = x;
                this.y = y;
                this.z = z;
                this.a = a;
                this.b = b;
                this.c = c;
                this.l = l;
                this.m = m;
                this.n = n;
                this.r = r;
                this.t = t;
                this.o = o;
            }

            public Bracket (Vertex[] lines) {
                for (int i = 0; i < lines.Length; ++i) {
                    if (i == 0) x = lines[i];
                    else if (i == 1) y = lines[i];
                    else if (i == 2) z = lines[i];
                    else if (i == 3) a = lines[i];
                    else if (i == 4) b = lines[i];
                    else if (i == 5) c = lines[i];
                    else if (i == 6) l = lines[i];
                    else if (i == 7) m = lines[i];
                    else if (i == 8) n = lines[i];
                    else if (i == 9) r = lines[i];
                    else if (i == 10) t = lines[i];
                    else if (i == 11) o = lines[i];
                    else break;
                }
            }

            public Bracket (Bracket bracket) {
                Bracket _bracket = new Bracket(bracket.Values);
                this.y = _bracket.y;
                this.z = _bracket.z;
                this.a = _bracket.a;
                this.b = _bracket.b;
                this.c = _bracket.c;
                this.l = _bracket.l;
                this.m = _bracket.m;
                this.n = _bracket.n;
                this.r = _bracket.r;
                this.t = _bracket.t;
                this.o = _bracket.o;
            }

            public bool CheckEdgeValue(Direction.Edges e, Point[] p) {
                if (_edges.TryGetValue(e, out HashSet<Point[]> result)) {
                    if (result != null && result.Contains(p)) {
                        return true;
                    }
                }
                return false;
            }

            public bool CheckFaceValue(Direction.Faces f, Vertex[] v)
            {
                if (_faces.TryGetValue(f, out HashSet<Vertex[]> result)) {
                    if (result != null && result.Contains(v)) {
                        return true;
                    }
                }
                return false;
            }

            public bool CheckFace(Direction.Faces f) {
                if (_faces.TryGetValue(f, out HashSet<Vertex[]> result)) {
                    if (result != null) {
                        return true;
                    }
                }
                return false;
            }

            public bool CheckEdge(Direction.Edges e) {
                if (_edges.TryGetValue(e, out HashSet<Point[]> result)) {
                    if (result != null) {
                        return true;
                    }
                }
                return false;
            }

            public void AddEdge(Direction.Edges e, Point[] p) {
                if (!CheckEdge(e)) {
                    _edges.Add(e, new HashSet<Point[]> { p });
                }
            }

            public void AddFace(Direction.Faces f, Vertex[] v) {
                if (!CheckFace(f)) {
                    _faces.Add(f, new HashSet<Vertex[]> { v });
                }
            }

            public void RemoveEdge(Direction.Edges e, Point[] p) {
                if (CheckEdge(e)) {
                    _edges.Remove(e);
                }
            }

            public void RemoveFace(Direction.Faces f, Vertex[] v) {
                if (CheckFace(f)) {
                    _faces.Remove((f));
                }
            }

            public void WalkEdge(Direction.Edges e, out Point[][] p) {
                int k = 0;
                p = new Point[_edges.Count][];
                if (CheckEdge(e)) {
                    foreach (Point[] _p in _edges[e]) {
                        p[k] = new Point[_p.Length];
                        for (int i = 0; i < _p.Length; ++i) {
                            p[k][i] = _p[i];
                        }
                        ++k;
                    }
                }
            }

            public void WalkFace(Direction.Faces f, out Vertex[][] v) {
                int k = 0;
                v = new Vertex[_faces.Count][];
                if (CheckFace(f)) {
                    foreach (Vertex[] _v in _faces[f]) {
                        v[k] = new Vertex[_v.Length];
                        for (int i = 0; i < _v.Length; i++) {
                            v[k][i] = _v[i];
                        }
                        ++k;
                    }
                }
            }

            public void ModifyEdge(Direction.Edges e, Point[] p, Point _p) {
                if (CheckEdgeValue(e, p)) {
                    Point[] __p = new Point[p.Length + 1];
                    p.CopyTo(__p, 0);
                    __p[p.Length] = _p;
                    _edges[e].Remove(p);
                    _edges[e].Add(__p);
                }
            }

            public void ModifyFace(Direction.Faces f, Vertex[] v, Vertex _v) {
                if (CheckFaceValue(f, v)) {
                    Vertex[] __v = new Vertex[v.Length + 1];
                    v.CopyTo(__v, 0);
                    __v[v.Length] = _v;
                    _faces[f].Remove(v);
                    _faces[f].Add(__v);
                }
            }

            public static Bracket operator +(Bracket x, Bracket y)
            {
                return new Bracket((x.x + y.x), (y.x + y.y));
            }

            public static Bracket operator -(Bracket x, Bracket y)
            {
                return new Bracket((x.x - y.x), (x.y - y.y));
            }

            public static Bracket operator *(Bracket x, Bracket y)
            {
                return new Bracket((x.x * x.y), (y.x * y.y));
            }

            public static Bracket operator /(Bracket x, Bracket y)
            {
                return new Bracket((x.x / y.x), (y.x / y.y));
            }

            public static Bracket operator %(Bracket x, Bracket y)
            {
                return new Bracket(x.x % y.x, x.y % y.y);
            }

            public static bool operator <(Bracket x, Bracket y)
            {
                return ((x.x + y.x) < (x.y + y.y)) ? true : false;
            }

            public static bool operator >(Bracket x, Bracket y)
            {
                return ((x.x + y.x) > (x.y + y.y)) ? true : false;
            }

            public static bool operator <=(Bracket x, Bracket y)
            {
                return ((x.x + y.x) <= (x.y + y.y)) ? true : false;
            }

            public static bool operator >=(Bracket x, Bracket y)
            {
                return ((x.x + y.x) >= (x.y + y.y)) ? true : false;
            }

            public static bool operator ==(Bracket x, Bracket y)
            {
                return ((x.x + y.x) == (x.y + y.y)) ? true : false;
            }

            public static bool operator !=(Bracket x, Bracket y)
            {
                return ((x.x + y.x) != (x.y + y.y)) ? true : false;
            }

            public override bool Equals(object obj)
            {
                return object.ReferenceEquals(this, obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static explicit operator Bracket(Vertex[] v)
            {
                if (v.Length > 12)
                    throw new Exception("Array length is not two");
                return new Bracket(v);
            }

            public static explicit operator Vertex[](Bracket b)
            {
                return new Vertex[12] { b.x, b.y, b.z, b.a, b.b, b.c, b.l, b.m, b.n, b.o, b.r, b.t };
            }

            public Bracket GetBracket {
                get { return this; }
            }

            public Vertex this[int index] {
                get {
                    Vertex k = null;
                    if (index == 0) k = x;
                    if (index == 1) k = y;
                    if (index == 2) k = z;
                    if (index == 3) k = a;
                    if (index == 4) k = b;
                    if (index == 5) k = c;
                    if (index == 6) k = l;
                    if (index == 7) k = m;
                    if (index == 8) k = n;
                    if (index == 9) k = r;
                    if (index == 10) k = t;
                    if (index == 11) k = o;
                    return k;
                }
                set {
                    if (index == 0) x = value;
                    if (index == 1) y = value;
                    if (index == 2) z = value;
                    if (index == 3) a = value;
                    if (index == 4) b = value;
                    if (index == 5) c = value;
                    if (index == 6) l = value;
                    if (index == 7) m = value;
                    if (index == 8) n = value;
                    if (index == 9) r = value;
                    if (index == 10) t = value;
                    if (index == 11) o = value;
                }
            }

            public Vertex[] Values {
                get { return new Vertex[] { x, y, z, a, b, c, l, m, n, r, t, o }; }
            }
        }
    }
}
