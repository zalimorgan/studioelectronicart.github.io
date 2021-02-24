static final int NUM_LINES = 2;

float t;

void setup() {
  background(20);
  size(800, 800);
}

void draw(){
  stroke(255);
  strokeWeight(1.5);
 
 translate(width/2, height/2);
 
 for (int i = 0; i < NUM_LINES; i++) {
  line(x1(t + i), y1(t + i), x2(t + i), y2(t + i));
 }
  t += .8;
}

Float x1(float t) {
return sin(t/20) * 100 + sin(t / 15) * 100;
}
  
  Float y1(float t) {
  return cos(t/20) * 100;
}

Float x2(float t) {
return sin(t/20) * 200 + sin(t/15) * 100;
}
  
  Float y2(float t) {
  return cos(t/20) * 200 + cos(t / 15) * 100;
}

// based on 1968 experiments in motion graphics https://archive.org/details/experimentsinmotiongraphics
//created referencing Alexander Miller parametric equations tutorial https://www.youtube.com/watch?v=LaarVR1AOvs
//the values for Sin and Cos have been altered as well as some of the basic set up functions. 
