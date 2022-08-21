using System;
using System.Collections.Generic;
using CSDK.Objects;

namespace CSDK {
    namespace Drawing {
	    class Transformations {
		    private Model model;
		    private double[][] _t;
		    private List<Point[][]> lines;
		    private Point[][] points;
		    private Location location;
            private Frame[] frames;

		    public Transformations (Model model) {
			    /*int t = 0;
                frames = model.Frames;// <<
			    lines = new List<Point[][]>();
			    points = new Point[36 * meshes.Length][];
			    for (int i = 0; i < meshes.Length; ++i) {
				    var blobs = meshes[i].Values;
				    points[i] = new Point[36 * blobs.Length];
				    for (int k = 0; k < blobs.Length; ++k) {
					    Position pos = new Position(blobs[k].GetBlob);
					    Line[] bracket1 = pos.Lines[0].Values;
					    Line[] bracket2 = pos.Lines[1].Values;
					    for (int q = 0; q < bracket1.Length + bracket2.Length; ++q) {
						    Point[] line;
						    if (q < bracket1.Length) line = bracket1[q].Values;
						    else line = bracket2[q].Values;
						    for (int o = 0; o < line.Length; ++o) {
							    double[] p = line[o].Values;
							    points[q + k] = new Point[4];
							    if (o == 0) points[t][0] = new Point(p[0]);
							    else if (o == 1) points[t][1] = new Point(p[1]);
							    else if (o == 2) points[t][2] = new Point(p[2]);
							    points[t][3] = new Point();
							    ++t;
						    }
					    }
				    }
				    lines.Add(points);
			    }
			    _t = new double[4][];
			    for (int i = 0; i < 4; ++i) 
                    _t[i] = new double[4];*/
		    }

		    public double[] Translate(Point sor, Point des) {
			    double x = sor.Values[0];
			    double y = sor.Values[1];
			    double z = sor.Values[2];
                _t[0] = new double[4] { 1 * x, 0, 0, des.Values[0] };
                _t[1] = new double[4] { 0, 1 * y, 0, des.Values[1] };
                _t[2] = new double[4] { 0, 0, 1 * z, des.Values[2] };
                _t[3] = new double[4] { 0, 0, 0, 1 };
			    double[] _temp = new double[4];
			    _temp[0] = _t[0][0] + _t[0][3];
			    _temp[1] = _t[1][1] + _t[1][3];
			    _temp[2] = _t[2][2] + _t[2][3];
			    _temp[3] = 1;
			    return _temp;
		    }

		    public double[] Scale(Point p) {
			    double x = p.Values[0];
                double y = p.Values[1];
                double z = p.Values[2];
                _t[0] = new double[4] { 1 * x, 0, 0, 0 };
                _t[1] = new double[4] { 0, 1 * y, 0, 0 };
                _t[2] = new double[4] { 0, 0, 1 * z, 0 };
                _t[3] = new double[4] { 0, 0, 0, 1 };
			    double[] temp = new double[4];
			    temp[0] = _t[0][0];
			    temp[1] = _t[1][1];
			    temp[2] = _t[2][2];
			    temp[3] = 1;
                return temp;
		    }

		    public double[] Shear(Point p, Point s1, Point s2) {
                double x = p.Values[0];
                double y = p.Values[1];
                double z = p.Values[2];
                _t[0] = new double[4] { 1 * x, s1.Values[0] * y, s1.Values[1] * z, 0 };
                _t[1] = new double[4] { s1.Values[2] * x, 1 * y, s2.Values[0] * z, 0 };
                _t[2] = new double[4] { s2.Values[1] * x, s2.Values[2] * y, 1 * z, 0 };
                _t[3] = new double[4] { 0, 0, 0, 1 };
                double[] temp = new double[4];
                temp[0] = _t[0][0] + _t[0][1] + _t[0][2];
			    temp[1] = _t[1][0] + _t[1][1] + _t[1][2];
			    temp[2] = _t[2][0] + _t[2][1] + _t[2][2];
			    temp[3] = 1;
			    return temp;
		    }

		    //Rotation, Reflection, and Transform will wait
	    }
    }
}
