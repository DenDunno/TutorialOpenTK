#version 330 core

layout(location = 0) in vec2 position;
layout(location = 1) in float vertexId;

out float id;

void main(void)
{
    id = vertexId;
    gl_Position = vec4(position, 0.0, 1.0);
}