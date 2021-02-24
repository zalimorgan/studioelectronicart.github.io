import peasy.*;

import ddf.minim.*;
import ddf.minim.analysis.*;
import ddf.minim.effects.*;
import ddf.minim.signals.*;
import ddf.minim.spi.*;
import ddf.minim.ugens.*;


Minim minim; 
AudioInput in; 
BeatDetect beat; 

PeasyCam cam;

void setup(){
size(1024, 763, P3D);

cam = new PeasyCam(this,500); 

minim = new Minim(this);
in= minim.getLineIn(Minim.STEREO, 1024);
beat = new BeatDetect();
beat.setSensitivity(400);
}

void draw() {
  background(0);
  
  cam.rotateY(0.04);
  cam.rotateX(0.01);
  cam.setDistance(580 + abs(sin(frameCount*8.01))*508);
 
  cam.beginHUD();
  for (int i = 0; i < width; i++) {
    stroke(255, in.mix.get(i)*500);
    line(i, height/2+in.mix.get(i)*308,i , height/2-in.mix.get(i)*300);
  }
  cam.endHUD();
 
  
  int total = 100; 
  PVector [][] pp = new PVector[total][total];
  
  for(int i= 0; i < total; i++){
    float lat = map(i, 0, total-1, -HALF_PI, HALF_PI);
    
    for (int j = 0; j < total; j++){
      float lon = map(j, 0, total-1, -PI, PI);
      
      int imnd = i + j * total;
      float r = 200 + in.mix.get(imnd%1024)*200;
      float x = r * cos(lat) *  cos(lon); 
      Float y = r * sin(lat) * cos(lon);
      float z = r * sin(lon);
      pp[i][j] = new PVector (x, y, z);
    }
  }
  for(int i = 0; i <total-1; i++){
    beginShape(TRIANGLE_STRIP);
    stroke(255, in.mix.get(i)*500);
    noFill();
    for (int j = 0; j < total; j++){ 
    vertex(pp[i][j].x, pp[i][j]. y, pp[i][j].z);
    vertex(pp[i+1][j].x, pp[i+1][j].y,pp[i+1][j].z);
    }
    endShape();
  }
  if(beat.isOnset())background(255);
}

// created referencing https://www.youtube.com/watch?v=fO1uW-xhwtA Live coding using REPL/Hot Swap Mode, using minim for audio
//libraries to add https://www.youtube.com/watch?v=51YzYapStTE
