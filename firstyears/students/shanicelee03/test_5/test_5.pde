static final int NUM_LINES=15; 

float t; 
float a; 
float x=300; 
float y=300; 
float angle; 

void setup (){
  background (20); 
  size (900,900); 
}

void draw () {
  background (255); 
  stroke (random (255), random (0), random (255)); 
  strokeWeight (.7); 
 
  translate (width/2, height/2); 
  
  for (int i=0; i<NUM_LINES; i++){
  line (x1 (t+i), y1(t+i), x2 (t+i), y2(t+i)); 
  line (x3(t-i), y3(t -i), x4(t -i ), y4(t - i)); 
  line (x5(t + i), y5(t + i), x6(t + i+ i), y6(t + i + i)); 
  point (x1(t/5), y1(t/5)); 
  point (x2(t), y2(t)); 
  point (x3(t), y3(t)); 
  point (x4(t), y4(t)); 
  point (x5(t*20), y5(t*20)); 
  point (x6(t*20), y6(t*20)); 

  }
      t+=.2; 
}



float x1(float t){
  return sin(t/10)*100 + sin(t/5)* 20 + sin (t/20)*50 + sin (t/10)*50; 
}

float y1(float t){
  return -cos (t/10)*100 + cos (t/20)*200 - cos(t/50)*10; 
}
 
 float x2(float t){
  return -sin(t/10)*200 + sin(t)* 10 + sin (t)*10;
}

float y2(float t){
  return cos (t/20)*100 + cos (t/12)*20;
}




float x3(float t){
  return -cos(t/10)*100; 
}

float y3(float t){
  return -sin(t/10)*300; 
}
 
 float x4(float t){
  return cos(t/100)*-200; 
}

float y4(float t){
  return sin(t/20)*100; 
}





float x5(float t){
  return cos(t/10)*200; 
}

float y5(float t){
  return sin(-t/10)*100 + sin(t/50)*400;
}
 
 float x6(float t){
  return -cos(t/10)*200 -cos (t/5)*100; 
}

float y6(float t){
  return sin(-t/20)*50 + sin (t/10)*100; 
}
