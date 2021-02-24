/* Based on stock example sketch 'Pulses' and YouTube Channel 'Coding Train's' videos on Perlin Noise.*/
float incr = 0.01;
color red = color(216,56,56);
color blue = color(24,160,246);
color dark = color(2,24,43);
float time = (second()/ width *TWO_PI);
float inc = 0.1;

void setup()
{
  size(800, 800);
  background(dark);
}

void draw()
{
  float xoff = noise(radians(inc));
  float yoff = cos(xoff) * TWO_PI;
        {
        noFill();
        stroke(blue);
        strokeWeight(0.2);
        arc(mouseX, mouseY += yoff, pmouseX += xoff, pmouseY += yoff,0,HALF_PI);
        }
        {
        noFill();
        stroke(red);
        strokeWeight(0.4);
        arc(mouseX, mouseY += yoff, pmouseX += xoff, pmouseY += yoff, 0+HALF_PI, PIE);
        }
    xoff *= time;
    inc += 0.1;
}
