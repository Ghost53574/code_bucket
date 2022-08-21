using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CSDK {
    namespace Objects {
	    [Serializable]
	    public class Objects {
		    private double height, length, depth;
		    private const double pi = 3.14159265;
		    private int t = 0;

		    public Objects(int t, Point point) {
			    double[] temp = point.Values;
			    this.t = t;
			    length = temp[0];
			    height = temp[1];
			    depth = temp[2];
		    }

	    	public Objects(Objects obj) {
			    t = obj.GetT;
			    length = obj.Length;
			    height = obj.Height;
			    depth = obj.Depth;
		    }

		    public double Height {
			    get { return height; }
		    }

		    public double Length {
			    get { return length; }
		    }

		    public double Depth {
		    	get { return depth; }
		    }

		    public double Radius {
			    get {
				    double temp = 0.0;
				    if (t == 4 || t == 5) temp = length / 2;
				    return temp;
			    }
		    }

		    public double Diameter {
			    get {
				    double temp = 0.0;
				    if (t == 4 || t == 5) temp = length;
				    return temp;
			    }
		    }

		    public double Area {
			    get {
				    double temp = 0.0;
				    switch (t) {
					    case 0://Square
						    temp = length * height;
						    break;
					    case 2://Triangle
						    double b = length / 2.0;
						    temp = (b * height) / 2;
						    break;
					    case 5://Circle
						    temp = pi * (this.Radius * this.Radius);
						    break;
				    }
				    return temp;
			    }
		    }

		    public double Volume {
			    get {
				    double temp = 0.0;
				    switch (t) {
					    case 1://Cube
						    temp = (height * length) * depth;
						    break;
					    case 3://Pyrimad
						    double b = length / 2.0;
						    temp = (b * height) / 3;
						    break;
					    case 4://Cone
						    //double _b = length / 2.0;//Fix
						    temp = pi * ((this.Radius * this.Radius) * height);
						    break;
					    case 6://Sphere
						    temp = (4 * (pi * (this.Radius * this.Radius * this.Radius))) / 3;
						    break;
				    }
				    return temp;
			    }
		    }

		    public int GetT {
			    get { return t; }
		    }		
	    }

	    [Serializable]
	    public class Square {
		    private Objects o;
            private Bracket square;

            public Square(double length, double height)
            {
                o = new Objects(0, new Point(length, height));
                Point p1 = new Point(0.0, 0.0);
                Point p2 = new Point(o.Length, 0.0);
                Point p3 = new Point(o.Length, o.Height);
                Point p4 = new Point(0.0, o.Height);
                Vertex l1 = new Vertex(p1, p2);
                Vertex l2 = new Vertex(p2, p3);
                Vertex l3 = new Vertex(p3, p4);
                Vertex l4 = new Vertex(p4, p1);
                square = new Bracket(l1, l2, l3, l4);
                square.AddRef(Direction.Faces.Top, new Vertex[] { l1 });
                square.AddRef(Direction.Faces.Right, new Vertex[] { l2 });
                square.AddRef(Direction.Faces.Bottom, new Vertex[] { l3 });
                square.AddRef(Direction.Faces.Left, new Vertex[] { l4 });
                square.AddRef(Direction.Edges.TopLeft, new Point[] { p1 });
                square.AddRef(Direction.Edges.TopRight, new Point[] { p2 });
                square.AddRef(Direction.Edges.BotLeft, new Point[] { p3 });
                square.AddRef(Direction.Edges.BotRight, new Point[] { p4 });
		    }

			public Square(Square square) {
				o = new Objects(square.Obj);
				this.square = new Bracket(square.Values);
			}

		    public Square GetSquare {
			    get { return this; }
		    }

		    public double Length {
			    get { return o.Length; }
		    }

		    public double Height {
			    get { return o.Height; }
		    }

		    public double Depth {
			    get { return o.Depth; }
		    }

		    public Objects Obj {
			    get { return o; }
		    }

		    public Bracket Values {
			    get { return square; }
		    }
	    }

	    [Serializable]
	    public class Cube {
		    private Objects o;
		    private Bracket cube;

		    public Cube(double length, double height, double depth) {
			    o = new Objects(1, new Point(length, length, depth));
			    Point p1 = new Point(0.0, 0.0, 0.0);
			    Point p2 = new Point(o.Length, 0.0, 0.0);
			    Point p3 = new Point(o.Length, o.Height, 0.0);
			    Point p4 = new Point(0.0, o.Height, 0.0);
			    Point p5 = new Point(0.0, 0.0, o.Depth);
			    Point p6 = new Point(o.Length, 0.0, o.Depth);
			    Point p7 = new Point(o.Length, o.Height, o.Depth);
			    Point p8 = new Point(0.0, o.Height, o.Depth);
                Point left = new Point(0.0, o.Height / 2, o.Depth / 2);
                Point right = new Point(o.Length, o.Height / 2, o.Depth / 2);
                Point top = new Point(o.Length / 2, o.Height, o.Depth / 2);
                Point bottom = new Point(o.Length / 2, 0.0, o.Depth / 2);
                Point back = new Point(o.Length / 2, o.Height / 2, o.Depth / 2);
                Point front = new Point(o.Length / 2, o.Height / 2, 0.0);
			    Vertex l1 = new Vertex(p1, p2);
			    Vertex l2 = new Vertex(p2, p3);
			    Vertex l3 = new Vertex(p3, p4);
			    Vertex l4 = new Vertex(p4, p1);
			    Vertex l5 = new Vertex(p1, p5);
			    Vertex l6 = new Vertex(p2, p6);
			    Vertex l7 = new Vertex(p3, p7);
			    Vertex l8 = new Vertex(p4, p8);
			    Vertex l9 = new Vertex(p5, p6);
			    Vertex l10 = new Vertex(p6, p7);
			    Vertex l11 = new Vertex(p7, p8);
			    Vertex l12 = new Vertex(p8, p6);
			    cube = new Bracket(l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12);
			    cube.AddRef(Direction.Faces.Left, left);
			    cube.AddRef(Direction.Faces.Right, right);
			    cube.AddRef(Direction.Faces.Top, top);
			    cube.AddRef(Direction.Faces.Bottom, bottom);
			    cube.AddRef(Direction.Faces.Front, front);
			    cube.AddRef(Direction.Faces.Bottom, bottom);
			    cube.AddRef(Direction.Edges.TopLeftX, topleftfront);
			    cube.AddRef(Direction.Edges.TopLeftY, topleftback);
			    cube.AddRef(Direction.Edges.TopRightX, toprightfront);
			    cube.AddRef(Direction.Edges.TopRightY, toprightback);
			    cube.AddRef(Direction.Edges.BotLeftX, botleftfront);
			    cube.AddRef(Direction.Edges.BotLeftY, botleftback);
			    cube.AddRef(Direction.Edges.BotRightX, botrightfront);
			    cube.AddRef(Direction.Edges.BotRightY, botrightback);
		    }

			public Cube(Cube cube) {
				o = new Objects(cube.Obj);
				this.cube = new Bracket(cube.Values);
			}

		    public Cube GetCube {
			    get { return this; }
		    }

		    public double Length {
			    get { return o.Length; }
		    }

		    public double Height {
		    	get { return o.Height; }
		    }

		    public double Depth {
			    get { return o.Depth; }
		    }

		    public Objects Obj {
			    get { return o; }
		    }

		    public Bracket Values {
			get { return cube; }
		    }

		    public Point[] Faces {
			    get { return cube.Faces; }
		    }

		    public List<KeyValuePair<Direction.Faces, Point>> GetFaces {
			    get { return cube.GetFaces; }
		    }

		    public List<KeyValuePair<Direction.Edges, Point>> GetEdges {
			    get { return cube.GetEdges; }
		    }
	    }

	    [Serializable]
	    public class Triangle {
		    private Objects o;
            private Bracket triangle;

		    public Triangle(double length, double height) {
			    o = new Objects(2, new Point(length, height));
			    Point p1 = new Point(0.0, 0.0);
			    Point p2 = new Point(o.Length, 0.0);
			    Point p3 = new Point(o.Length / 2.0, o.Height);
			    Vertex l1 = new Vertex(p1, p2);
			    Vertex l2 = new Vertex(p2, p3);
			    Vertex l3 = new Vertex(p3, p1);
			    triangle = new Bracket(l1, l2, l3);
                triangle.AddRef(Direction.Faces.Bottom, l1);
                triangle.AddRef(Direction.Faces.Right, l2);
                triangle.AddRef(Direction.Faces.Left, l3);
		    }

			public Triangle(Triangle triangle) {
				o = new Objects(triangle.Obj);
				this.triangle = new Bracket(triangle.Values);
			}

		    public Triangle GetTriangle {
			    get { return this; }
		    }

		    public double Length {
			    get { return o.Length; }
		    }

		    public double Height {
			    get { return o.Height; }
		    }

		    public double Depth {
			    get { return o.Depth; }
		    }

		    public Objects Obj {
			    get { return o; }
		    }

		    public Bracket Values {
			    get { return triangle; }
		    }
	    }

	    [Serializable]
	    public class Pyrimad {
		    private Objects o;
		    private Bracket pyrimad;

		    public Pyrimad(double length, double height, double depth) {
			    o = new Objects(3, new Point(length, height, depth));
			    Point p1 = new Point(0.0, 0.0, 0.0);
			    Point p2 = new Point(o.Length, 0.0, 0.0);
			    Point p3 = new Point(0.0, 0.0, o.Depth);
			    Point p4 = new Point(o.Length, 0.0, o.Depth);
			    Point p5 = new Point(o.Length / 2, o.Height, o.Depth / 2);
			    Vertex l1 = new Vertex(p1, p2);
			    Vertex l2 = new Vertex(p2, p5);
			    Vertex l3 = new Vertex(p5, p1);
			    Vertex l4 = new Vertex(p3, p4);
			    Vertex l5 = new Vertex(p4, p5);
			    Vertex l6 = new Vertex(p5, p3);
			    Vertex l7 = new Vertex(p1, p3);
			    Vertex l8 = new Vertex(p2, p4);
			    Point left = new Point(0.0, o.Height / 2, o.Depth / 1.5);
			    Point right = new Point(o.Length, o.Height / 2, o.Depth / 1.5);
			    Point top = p5;
			    Point bottom = new Point(o.Length / 2, 0.0, o.Depth / 2);
			    Point front = new Point(o.Length / 2, o.Height / 2, 0.0);
			    Point back = new Point(o.Length / 2, o.Height / 2, o.Depth / 1.5);
			    pyrimad = new Bracket(left, right, bottom, front, back, l1, l2, l3, l4, l5, l6, l7, l8);
                Point botleftfront = p1;
                Point botleftback = p3;
                Point botrightfront = p2;
                Point botrightback = p4;
			    Point topmid = p5;
			    pyrimad.AddRef(Direction.Faces.Left, left);
			    pyrimad.AddRef(Direction.Faces.Right, right);
			    pyrimad.AddRef(Direction.Faces.Top, top);
			    pyrimad.AddRef(Direction.Faces.Bottom, bottom);
			    pyrimad.AddRef(Direction.Faces.Front, front);
			    pyrimad.AddRef(Direction.Faces.Back, back);
			    pyrimad.AddRef(Direction.Edges.BotLeftX, botleftfront);
			    pyrimad.AddRef(Direction.Edges.BotLeftY, botleftback);
			    pyrimad.AddRef(Direction.Edges.BotRightX, botrightfront);
			    pyrimad.AddRef(Direction.Edges.BotRightY, botrightback);
			    pyrimad.AddRef(Direction.Edges.TopMiddle, topmid);
		    }

			public Pyrimad(Pyrimad pyrimad) {
				o = new Objects(pyrimad.Obj);
				this.pyrimad = new Bracket(pyrimad.Values);
			}

		    public Pyrimad GetPyrimad {
			    get { return this; }
		    }

		    public double Length {
			    get { return o.Length; }
		    }

		    public double Height {
		    	get { return o.Height; }
		    }

		    public double Depth {
		    	get { return o.Depth; }
		    }

		    public Objects Obj {
			    get { return o; }
		    }

		    public Bracket Values {
			    get { return pyrimad; }
		    }

		    public Point[] Faces {
			    get { return pyrimad.Faces; }
		    }

		    public List<KeyValuePair<Direction.Faces, Point>> GetFaces {
			    get { return pyrimad.GetFaces; }
		    }

		    public List<KeyValuePair<Direction.Edges, Point>> GetEdges {
			    get { return pyrimad.GetEdges; }
		    }
	    }

	    [Serializable]
	    public class Cone {
		    private Objects o;
		    private Bracket cone;

		    public Cone(double length, double height, double depth) {
			    o = new Objects(4, new Point(length, height, depth));
			    Point p1 = new Point(0.0, 0.0, 0.0);
			    Point p2 = new Point(o.Length / 2, 0.0, o.Depth / 4);
			    Point p3 = new Point(o.Length, 0.0, o.Depth / 2);
			    Point p4 = new Point(o.Length / 2, 0.0, o.Depth / 1.5);
			    Point p5 = new Point(0.0, 0.0, o.Depth);
			    Point p6 = new Point(-(o.Length / 2), 0.0, o.Depth / 1.5);
			    Point p7 = new Point(-(o.Length), 0.0, o.Depth / 2);
			    Point p8 = new Point(-(o.Length / 2), 0.0, o.Depth / 4);
			    Point p9 = new Point(0.0, o.Height, o.Depth / 2);
			    Vertex l1 = new Vertex(p1, p2);
			    Vertex l2 = new Vertex(p3, p4);
			    Vertex l3 = new Vertex(p5, p6);
			    Vertex l4 = new Vertex(p7, p8);
			    Vertex l5 = new Vertex(p1, p9);
			    Vertex l6 = new Vertex(p2, p9);
			    Vertex l7 = new Vertex(p3, p9);
		    	Vertex l8 = new Vertex(p4, p9);
			    Vertex l9 = new Vertex(p5, p9);
			    Vertex l10 = new Vertex(p6, p9);
		    	Vertex l11 = new Vertex(p7, p9);
			    Vertex l12 = new Vertex(p8, p9);
			    Point top = p9;
			    Point bottom = new Point(0.0, o.Length / 2, o.Depth / 2);
			    cone = new Bracket(bottom, l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12);
                Point botleftfront = p2;
                Point botleftback = p4;
                Point botrightfront = p6;
			    Point botrightback = p8;
                /* * * * * * * * * * * * * * *
                 * What about the sides of the cone?
                 * What about a cylindar?
                 */
			    cone.AddRef(Direction.Faces.Top, top);
			    cone.AddRef(Direction.Faces.Bottom, bottom);
			    cone.AddRef(Direction.Edges.BotLeftX, botleftfront);
			    cone.AddRef(Direction.Edges.BotLeftY, botleftback);
			    cone.AddRef(Direction.Edges.BotRightX, botrightfront);
			    cone.AddRef(Direction.Edges.BotRightY, botrightback);
		    }

			public Cone(Cone cone) {
				o = new Objects(cone.Obj);
				this.cone = new Bracket(cone.Values);
			}

		    public Cone GetCone {
			    get { return this; }
		    }

		    public double Length {
			    get { return o.Length; }
		    }

		    public double Height {
			    get { return o.Height; }
		    }

		    public double Depth {
			    get { return o.Depth; }
		    }

		    public Objects Obj {
			    get { return o; }
		    }

		    public Bracket Values {
			    get { return cone; }
		    }

		    public Point[] Faces {
			    get { return cone.Faces; }
		    }

		    public List<KeyValuePair<Direction.Faces, Point>> GetFaces {
			    get { return cone.GetFaces; }
		    }

		    public List<KeyValuePair<Direction.Edges, Point>> GetEdges {
			    get { return cone.GetEdges; }
		    }
	    }

	    [Serializable]
	    public class Circle {
		    private Objects o;
		    private Bracket circle;

		    public Circle(double length, double height) {
			    o = new Objects(5, new Point(length, height));
			    Point p1 = new Point(0.0, 0.0);
			    Point p2 = new Point(o.Length / 2, o.Height / 4);
			    Point p3 = new Point(o.Length, o.Height / 2);
			    Point p4 = new Point(o.Length / 2, o.Height / 1.5);
			    Point p5 = new Point(0.0, o.Height);
			    Point p6 = new Point(-(o.Length / 2), o.Height / 1.5);
			    Point p7 = new Point(-(o.Length), o.Height / 2);
			    Point p8 = new Point(-(o.Length / 2), o.Height / 4);
                Vertex l1 = new Vertex(p1, p2);
                Vertex l2 = new Vertex(p3, p4);
			    Vertex l3 = new Vertex(p5, p6);
			    Vertex l4 = new Vertex(p7, p8);
			    circle = new Bracket(l1, l2, l3, l4);
                circle.AddRef(Direction.Faces.Front, ));
		    }

			public Circle(Circle circle) {
				o = new Objects(circle.Obj);
				this.circle = new Bracket(circle.Values);
			}

		    public Circle GetCircle {
			    get { return this; }
		    }

		    public double Length {
			    get { return o.Length; }
		    }

		    public double Height {
			    get { return o.Height; }
		    }

		    public double Depth {
			    get { return o.Depth; }
		    }

		    public Objects Obj {
			    get { return o; }
		    }

		    public Bracket Values {
			    get { return circle; }
		    }
	    }

	    [Serializable]
	    public class Sphere {
		    private Objects o;
		    private Bracket sphere;

		    public Sphere(double length, double height, double depth) {
			    o = new Objects(6, new Point(length, height, depth));
			    Point p1 = new Point(0.0, 0.0, 0.0);
                Point p2 = new Point(o.Length / 2, o.Height / 4, 0.0);
                Point p3 = new Point(o.Length, o.Height / 2, 0.0);
                Point p4 = new Point(o.Length / 2, o.Height / 1.5, 0.0);
                Point p5 = new Point(0.0, o.Height, 0.0);
                Point p6 = new Point(-(o.Length / 2), o.Height / 1.5, 0.0);
                Point p7 = new Point(-(o.Length), o.Height / 2, 0.0);
                Point p8 = new Point(-(o.Length / 2), o.Height / 4, 0.0);
			    Point p9 = new Point(0.0, 0.0, o.Depth);
			    Point p10 = new Point(o.Length / 2, o.Height / 4, o.Depth);
			    Point p11 = new Point(o.Length, o.Height / 2, o.Depth);
			    Point p12 = new Point(o.Length / 2, o.Height / 1.5, o.Depth);
			    Point p13 = new Point(0.0, o.Height, o.Depth);
			    Point p14 = new Point(-(o.Length / 2), o.Height / 1.5, o.Depth);
			    Point p15 = new Point(-(o.Length), o.Height / 2, o.Depth);
			    Point p16 = new Point(-(o.Length / 2), o.Height / 4, o.Depth);
                Vertex l1 = new Vertex(p1, p2);
                Vertex l2 = new Vertex(p3, p4);
                Vertex l3 = new Vertex(p5, p6);
                Vertex l4 = new Vertex(p7, p8);
                Vertex l5 = new Vertex(p9, p10);
			    Vertex l6 = new Vertex(p11, p12);
			    Vertex l7 = new Vertex(p13, p14);
			    Vertex l8 = new Vertex(p15, p16);
			    Point top = new Point(o.Length / 2, o.Height, o.Depth / 2);
			    Point bottom = new Point(o.Length / 2, 0.0, o.Depth / 2);
			    Point left = new Point(0.0, o.Height / 2, o.Depth / 2);
			    Point right = new Point(o.Length, o.Height / 2, o.Depth / 2);
			    Point front = new Point(o.Length / 2, o.Height / 2, 0.0);
			    Point back = new Point(o.Length / 2, o.Height / 2, o.Depth  / 2);
			    sphere = new Bracket(l1, l2, l3, l4, l5, l6, l7, l8);
			    sphere.AddRef(Direction.Faces.Top, top);
			    sphere.AddRef(Direction.Faces.Bottom, bottom);
			    sphere.AddRef(Direction.Faces.Left, left);
			    sphere.AddRef(Direction.Faces.Right, right);
			    sphere.AddRef(Direction.Faces.Front, front);
			    sphere.AddRef(Direction.Faces.Back, back);
		    }

			public Sphere(Sphere sphere) {
				o = new Objects(sphere.Obj);
				this.sphere = new Bracket(sphere.Values);
			}

		    public Sphere GetSphere {
			    get { return this; }
		    }

		    public double Height {
			    get { return o.Height; }
		    }

		    public double Length {
			    get { return o.Length; }
		    }

		    public double Depth {
			    get { return o.Depth; }
		    }

		    public Objects Obj {
			    get { return o; }
		    }

		    public Bracket Values {
			    get { return sphere; }
		    }

		    public Point[] Faces {
			    get { return sphere.Faces; }
		    }

		    public List<KeyValuePair<Direction.Faces, Point>> GetFaces {
			    get { return sphere.GetFaces; }
		    }

		    public List<KeyValuePair<Direction.Edges, Point>> GetEdges {
			    get { return sphere.GetEdges; }
		    }
	    }

        [Serializable]
        public class Blob {
            private Objects o;
            private Bracket blob;

            private Guid id;

            /* Generates Vertex objects from Bracket objects
            * to add direction to each line in the bracket.
            * The only difference between a bracket (a group
            * of lines) and a blob is that a blob is a group
            * of vertexes with addational information about
            * the object that would be directly useful for
            * parent objects. */

            private void GenerateId() {
                
            }

            public Blob(Bracket bracket)
            {
                GenerateId();
                o = new Objects(7, new Point())
                this.blob = bracket;
            }

            public Blob(Blob obj)
            {
                this.blob = obj.GetVertecies;
                this.name = obj.name;
            }

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }

            public Blob GetBlob()
            {
                return this;
            }

            public Vertex[] GetVertecies
            {
                get
                {
                    return blob;
                }
            }

            public Vertex this[int index]
            {
                get
                {
                    return blob[index];
                }
                set
                {
                    blob[index] = value;
                }
            }

        }
    }
}
