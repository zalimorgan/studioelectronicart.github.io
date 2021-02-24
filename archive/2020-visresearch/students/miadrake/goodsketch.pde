int angle = 0;

void setup() {
  size(600, 600);
  background(#cc0099);
  stroke(500);
  stroke(#FFCC00);
  fill(100,100);
}

void draw() {
  
  if (mousePressed == true) {
    angle += 30;
    float val = cos(radians(angle)) * 30.0;
    for (int a = 0; a < 360; a += 75) {
      float xoff = cos(radians(a)) * val;
      float yoff = sin(radians(a)) * val;
      fill(#FF0099);
      ellipse(mouseX + xoff, mouseY + yoff, val, val);
    }
    fill(255);
    ellipse(mouseX, mouseY, 2, 2);
  
  }
    else {
       angle += 30;}
    float val = cos(radians(angle)) * 30.0;
    for (int a = 0; a < 360; a += 75) {
      float xoff = cos(radians(a)) * val;
      float yoff = sin(radians(a)) * val;
      fill(#FF00FF);
      ellipse(mouseX, mouseY, val, val);
    }
    
      
  }
