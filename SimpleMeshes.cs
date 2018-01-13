﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Fusee.Serialization;

namespace Fusee.Tutorial.Core
{
    public static class SimpleMeshes 
    {
        public static MeshComponent CreateCuboid(float3 size)
        {
            return new MeshComponent
            {
                Vertices = new[]
                {
                    // left, bottom, front vertex
                    new float3(-0.5f*size.x, -0.5f*size.y, -0.5f*size.z), // 0  - belongs to left
                    new float3(-0.5f*size.x, -0.5f*size.y, -0.5f*size.z), // 1  - belongs to bottom
                    new float3(-0.5f*size.x, -0.5f*size.y, -0.5f*size.z), // 2  - belongs to front

                    // left, bottom, back vertex
                    new float3(-0.5f*size.x, -0.5f*size.y,  0.5f*size.z),  // 3  - belongs to left
                    new float3(-0.5f*size.x, -0.5f*size.y,  0.5f*size.z),  // 4  - belongs to bottom
                    new float3(-0.5f*size.x, -0.5f*size.y,  0.5f*size.z),  // 5  - belongs to back

                    // left, up, front vertex
                    new float3(-0.5f*size.x,  0.5f*size.y, -0.5f*size.z),  // 6  - belongs to left
                    new float3(-0.5f*size.x,  0.5f*size.y, -0.5f*size.z),  // 7  - belongs to up
                    new float3(-0.5f*size.x,  0.5f*size.y, -0.5f*size.z),  // 8  - belongs to front

                    // left, up, back vertex
                    new float3(-0.5f*size.x,  0.5f*size.y,  0.5f*size.z),  // 9  - belongs to left
                    new float3(-0.5f*size.x,  0.5f*size.y,  0.5f*size.z),  // 10 - belongs to up
                    new float3(-0.5f*size.x,  0.5f*size.y,  0.5f*size.z),  // 11 - belongs to back

                    // right, bottom, front vertex
                    new float3( 0.5f*size.x, -0.5f*size.y, -0.5f*size.z), // 12 - belongs to right
                    new float3( 0.5f*size.x, -0.5f*size.y, -0.5f*size.z), // 13 - belongs to bottom
                    new float3( 0.5f*size.x, -0.5f*size.y, -0.5f*size.z), // 14 - belongs to front

                    // right, bottom, back vertex
                    new float3( 0.5f*size.x, -0.5f*size.y,  0.5f*size.z),  // 15 - belongs to right
                    new float3( 0.5f*size.x, -0.5f*size.y,  0.5f*size.z),  // 16 - belongs to bottom
                    new float3( 0.5f*size.x, -0.5f*size.y,  0.5f*size.z),  // 17 - belongs to back

                    // right, up, front vertex
                    new float3( 0.5f*size.x,  0.5f*size.y, -0.5f*size.z),  // 18 - belongs to right
                    new float3( 0.5f*size.x,  0.5f*size.y, -0.5f*size.z),  // 19 - belongs to up
                    new float3( 0.5f*size.x,  0.5f*size.y, -0.5f*size.z),  // 20 - belongs to front

                    // right, up, back vertex
                    new float3( 0.5f*size.x,  0.5f*size.y,  0.5f*size.z),  // 21 - belongs to right
                    new float3( 0.5f*size.x,  0.5f*size.y,  0.5f*size.z),  // 22 - belongs to up
                    new float3( 0.5f*size.x,  0.5f*size.y,  0.5f*size.z),  // 23 - belongs to back

                },
                Normals = new[]
                {
                    // left, bottom, front vertex
                    new float3(-1,  0,  0), // 0  - belongs to left
                    new float3( 0, -1,  0), // 1  - belongs to bottom
                    new float3( 0,  0, -1), // 2  - belongs to front

                    // left, bottom, back vertex
                    new float3(-1,  0,  0),  // 3  - belongs to left
                    new float3( 0, -1,  0),  // 4  - belongs to bottom
                    new float3( 0,  0,  1),  // 5  - belongs to back

                    // left, up, front vertex
                    new float3(-1,  0,  0),  // 6  - belongs to left
                    new float3( 0,  1,  0),  // 7  - belongs to up
                    new float3( 0,  0, -1),  // 8  - belongs to front

                    // left, up, back vertex
                    new float3(-1,  0,  0),  // 9  - belongs to left
                    new float3( 0,  1,  0),  // 10 - belongs to up
                    new float3( 0,  0,  1),  // 11 - belongs to back

                    // right, bottom, front vertex
                    new float3( 1,  0,  0), // 12 - belongs to right
                    new float3( 0, -1,  0), // 13 - belongs to bottom
                    new float3( 0,  0, -1), // 14 - belongs to front

                    // right, bottom, back vertex
                    new float3( 1,  0,  0),  // 15 - belongs to right
                    new float3( 0, -1,  0),  // 16 - belongs to bottom
                    new float3( 0,  0,  1),  // 17 - belongs to back

                    // right, up, front vertex
                    new float3( 1,  0,  0),  // 18 - belongs to right
                    new float3( 0,  1,  0),  // 19 - belongs to up
                    new float3( 0,  0, -1),  // 20 - belongs to front

                    // right, up, back vertex
                    new float3( 1,  0,  0),  // 21 - belongs to right
                    new float3( 0,  1,  0),  // 22 - belongs to up
                    new float3( 0,  0,  1),  // 23 - belongs to back
                },
                Triangles = new ushort[]
                {
                    0,  6,  3,     3,  6,  9,  // left
                    2, 14, 20,     2, 20,  8,  // front
                    12, 15, 18,    15, 21, 18, // right
                    5, 11, 17,    17, 11, 23,  // back
                    7, 22, 10,     7, 19, 22,  // top
                    1,  4, 16,     1, 16, 13,  // bottom 
                },
                UVs = new float2[]
                {
                    // left, bottom, front vertex
                    new float2( 1,  0), // 0  - belongs to left
                    new float2( 1,  0), // 1  - belongs to bottom
                    new float2( 0,  0), // 2  - belongs to front

                    // left, bottom, back vertex
                    new float2( 0,  0),  // 3  - belongs to left
                    new float2( 1,  1),  // 4  - belongs to bottom
                    new float2( 1,  0),  // 5  - belongs to back

                    // left, up, front vertex
                    new float2( 1,  1),  // 6  - belongs to left
                    new float2( 0,  0),  // 7  - belongs to up
                    new float2( 0,  1),  // 8  - belongs to front

                    // left, up, back vertex
                    new float2( 0,  1),  // 9  - belongs to left
                    new float2( 0,  1),  // 10 - belongs to up
                    new float2( 1,  1),  // 11 - belongs to back

                    // right, bottom, front vertex
                    new float2( 0,  0), // 12 - belongs to right
                    new float2( 0,  0), // 13 - belongs to bottom
                    new float2( 1,  0), // 14 - belongs to front

                    // right, bottom, back vertex
                    new float2( 1,  0),  // 15 - belongs to right
                    new float2( 0,  1),  // 16 - belongs to bottom
                    new float2( 0,  0),  // 17 - belongs to back

                    // right, up, front vertex
                    new float2( 0,  1),  // 18 - belongs to right
                    new float2( 1,  0),  // 19 - belongs to up
                    new float2( 1,  1),  // 20 - belongs to front

                    // right, up, back vertex
                    new float2( 1,  1),  // 21 - belongs to right
                    new float2( 1,  1),  // 22 - belongs to up
                    new float2( 0,  1),  // 23 - belongs to back                    
                },
                BoundingBox = new AABBf(-0.5f * size, 0.5f*size)
            };
        }

        public static MeshComponent CreateCylinder(float radius, float height, int segments)
        {
            //  Initialisation of Arrays for vertices, normals and triangles
            float3[] verts = new float3[4 * segments + 2];
            float3[] norms = new float3[4 * segments + 2];
            ushort[] tris = new ushort[2 * (segments * 3) + (segments * 6)];

            // Calculation of delta, the angle between two segments
            float delta = (2 * M.Pi) / segments;

            // the vert on top in the middle of the cylinder
            verts[segments] = new float3(0, 0.5f * height, 0);
            norms[segments] = float3.UnitY;

            // the vert on the side on top (without any z-value)
            verts[0] = new float3(radius, 0.5f * height, 0);
            norms[0] = float3.UnitY;

            // the same vert as above, but with the norm towards the side (x = 1)
            verts[segments + 1] = new float3(radius, 0.5f * height, 0);
            norms[segments + 1] = new float3(1, 0, 0);

            // the same vert as above, but at the bottom
            verts[(segments*2) + 1] = new float3(radius, -0.5f * height, 0);
            norms[(segments*2) + 1] = new float3(1, 0, 0);

            // the same verts as above at the bottom, but the normal directing towards the bottom
            verts[(segments*3) + 1] = new float3(radius, -0.5f * height, 0);
            norms[(segments*3) + 1] = -(float3.UnitY);

            // the vert at the buttom in the middle of the cylinder
            verts[(segments*4) + 1] = new float3(0, -0.5f * height, 0);
            norms[(segments*4) + 1] = -(float3.UnitY);
            
            for(int i = 1; i < segments; i++)
            {
                // verts and norms on top with norms towards the top
                verts[i] = new float3(radius * M.Cos(i * delta), 0.5f * height, radius * M.Sin(i * delta));
                norms[i] = float3.UnitY;

                // verts and norms on top with norms towards the side
                verts[segments + i + 1] = new float3(radius * M.Cos(i * delta), 0.5f * height, radius * M.Sin(i* delta));
                norms[segments + i + 1] = new float3(M.Cos(i * delta), 0, M.Sin(i * delta));

                // verts and norms at the bottom with norms towards the side
                verts[(segments*2) + i + 1] = new float3(radius * M.Cos(i * delta), -0.5f * height, radius * M.Sin(i* delta));
                norms[(segments*2) + i + 1] = new float3(M.Cos(i * delta), 0, M.Sin(i * delta));

                // verts and norms at the bottom with norms towards the bottom
                verts[(segments*3) + i + 1] = new float3(radius * M.Cos(i * delta), -0.5f * height, radius * M.Sin(i * delta));
                norms[(segments*3) + i + 1] = -(float3.UnitY);

                // triangles on top 
                tris[3*i - 1] = (ushort) segments;
                tris[3*i - 2] = (ushort) i; 
                tris[3*i - 3] = (ushort) (i-1);

                // triangles from top to bottom
                tris[segments * 3 + (3*i - 1)] = (ushort) (segments * 2 + i);
                tris[segments * 3 + (3*i - 2)] = (ushort) (segments + i);
                tris[segments * 3 + (3*i - 3)] = (ushort) (segments + i + 1);

                // triangles from bottom to top
                tris[segments * 6 + (3*i - 1)] = (ushort) (segments * 2 + i + 1);
                tris[segments * 6 + (3*i - 2)] = (ushort) (segments * 2 + i);
                tris[segments * 6 + (3*i - 3)] = (ushort) (segments + i + 1);

                // triangles at the bottom
                tris[segments * 9 + (3*i - 1)] = (ushort) (segments * 4 + 1 - i);
                tris[segments * 9 + (3*i - 2)] = (ushort) (segments * 4 + 1);
                tris[segments * 9 + (3*i - 3)] = (ushort) (segments * 4 - i);
            }
            // last triangle on top
            tris[3 * segments - 1] = (ushort) segments;
            tris[3 * segments - 2] = (ushort) 0;
            tris[3 * segments - 3] = (ushort) (segments - 1);
            // last triangle from top to bottom
            tris[6 * segments - 1] = (ushort) (segments * 3);
            tris[6 * segments - 2] = (ushort) (segments * 2);
            tris[6 * segments - 3] = (ushort) (segments + 1);
            // last triangle from bottom to top
            tris[9 * segments - 1] = (ushort) (segments + 1);
            tris[9 * segments - 2] = (ushort) (segments * 2 + 1);
            tris[9 * segments - 3] = (ushort) (segments * 3);
            // last triangle at the bottom           
            tris [12 * segments - 1] = (ushort) (segments * 3 + 1);
            tris [12 * segments - 2] = (ushort) (segments * 4 + 1);
            tris [12 * segments - 3] = (ushort) (segments * 4);

            
            return new MeshComponent
            { 
                Vertices = verts,
                Normals = norms,
                Triangles = tris,
            };

        }

/*     public static MeshComponent CreateCylinder(float radius, float height, int segments)
        {
            return CreateConeFrustum(radius, radius, height, segments);
        }
*/
        public static MeshComponent CreateCone(float radius, float height, int segments)
        {
            return CreateConeFrustum(radius, 0.0f, height, segments);
        }

        public static MeshComponent CreateConeFrustum(float radiuslower, float radiusupper, float height, int segments)
        {
            throw new NotImplementedException();
        }


        public static MeshComponent CreatePyramid(float baselen, float height)
        {
            throw new NotImplementedException();
        }
        public static MeshComponent CreateTetrahedron(float edgelen)
        {
            throw new NotImplementedException();
        }

        public static MeshComponent CreateTorus(float mainradius, float segradius, int segments, int slices)
        {
            throw new NotImplementedException();
        }

    }
}
