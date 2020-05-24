static final int NUM_LINES = 2;

float t;

void setup() {
  background(20);
  size(800, 800);
}

void draw(){
  stroke(255);
  strokeWeight(5);
 
 translate(width/2, height/2);
 
point(x1(t), y1(t));
point(x2(t), y2(t));
t++;
}

Float x1(float t) {
return sin(t / 10) * 200 + sin(t / 34) * 20;
}
  
  Float y1(float t) {
  return cos(t/50) * 200;
}
Float x2(float t) {
return sin(t / 100) * 200 + sin(t) * 50;
}
  
  Float y2(float t) {
  return sin(t/20) * 30;
}

// based on 1968 experiments in motion graphics https://archive.org/details/experimentsinmotiongraphics
//created referencing Alexander Miller parametric equations tutorial https://www.youtube.com/watch?v=LaarVR1AOvs
//the values for Sin and Cos have been altered as well as some of the basic set up functions. 
