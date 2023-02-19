#version 330 core

uniform vec4[30] colors; // 30 is like Capacity in List. It is NOT Count
uniform int colorsCount; // real Count

in float id;

out vec4 outputColor;

void main()
{    
    outputColor = colors[int(id) % colorsCount];   
}