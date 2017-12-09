using System;
using System.Collections.Generic;
using System.Linq;
using Fusee.Base.Common;
using Fusee.Base.Core;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Fusee.Serialization;
using Fusee.Xene;
using static System.Math;
using static Fusee.Engine.Core.Input;
using static Fusee.Engine.Core.Time;
using System.Diagnostics;

namespace Fusee.Tutorial.Core
{
    public class FirstSteps : RenderCanvas
    {
        private SceneContainer _scene;
        private SceneRenderer _sceneRenderer;
        private float _camAngle = 0;

        private TransformComponent _cubeTransform;
        // Init is called on startup. 
        public override void Init()
        {
            // Set the clear color for the backbuffer to light green (intensities in R, G, B, A).
            RC.ClearColor = new float4(1, 0.7f, 0.5f, 1.0f);

            _cubeTransform = new TransformComponent {Scale = new float3(1, 1, 1), Translation = new float3(0, 0, 0)};

            TransformComponent []transformArray = new TransformComponent[20];
            int i;
            float valueChange = 0;
            float valueComp1 = 38.4f;
            float valueComp2 = -4.5f;
            float valueComp3 = 0;

            for (i = 0; i < (transformArray.Length/2); i++)
            {  
                valueComp1 = valueComp1 - 6.4f;
                if (valueComp1 > 0)
                {
                    valueComp2 = valueComp2 + 4.5f - valueChange;
                }
                if (valueComp1 > 0)
                {
                    valueChange = valueChange + 0.9f;
                }

                if(valueComp1 < 1 && valueComp1 > 0)
                valueComp2 = valueComp2 + 0.9f;
                if (valueComp1 > -7 && valueComp1 < -5)
                {
                valueComp2 = valueComp2 - 0.9f;
                valueChange = valueChange - 0.9f;
                }

                if (valueComp1 <= 0)
                {
                    valueComp2 = valueComp2 - 4.5f + valueChange;
                } 
                if (valueComp1 < 0)
                {
                    valueChange = valueChange - 0.9f;
                }
                transformArray[i] = new TransformComponent {Scale = new float3(1, 1, 1), Rotation = new float3(3, 1, 1), Translation = new float3(valueComp1, valueComp2, valueComp3)};
            };
            valueComp1 = -38.4f;
            valueComp2 = 4.5f;
            valueChange = 0;

            for (i = i; i < transformArray.Length; i++)
            {  
                valueComp1 = valueComp1 + 6.4f;
                if (valueComp1 < 0)
                {
                    valueComp2 = valueComp2 - 4.5f + valueChange;
                }
                if (valueComp1 < 0)
                {
                    valueChange = valueChange + 0.9f;
                }
                if(valueComp1 < 1 && valueComp1 > -1)
                {
                valueComp2 = valueComp2 - 0.9f;
                }                                
                if (valueComp1 > 5 && valueComp1 < 7)
                {
                valueComp2 = valueComp2 + 0.9f;
                valueChange = valueChange - 0.9f;
                }
                if (valueComp1 >= 0)
                {
                    valueComp2 = valueComp2 + 4.5f - valueChange;
                }
                if (valueComp1 > 0)
                {
                    valueChange = valueChange - 0.9f;
                }


                transformArray[i] = new TransformComponent {Scale = new float3(1, 1, 1), Rotation = new float3(3, 1, 1), Translation = new float3(valueComp1, valueComp2, valueComp3)};
            };

            var cubeMaterialRing = new MaterialComponent
            {
                Diffuse = new MatChannelContainer {Color = new float3(0.3f, 0.5f, 0.7f)},
                Specular = new SpecularChannelContainer {Color = float3.One, Shininess = 4}
            };
            
            var cubeTransform = new TransformComponent {Scale = new float3(1, 1, 1), Translation = new float3(0, 0, 0)};
            var cubeMaterial = new MaterialComponent
            {
                Diffuse = new MatChannelContainer {Color = new float3(0.8f, 0.2f, 0.2f)},
                Specular = new SpecularChannelContainer {Color = float3.One, Shininess = 3}
            };
            var cubeMesh = SimpleMeshes.CreateCuboid(new float3(12, 5, 20));
            var cubeMeshRing = SimpleMeshes.CreateCuboid(new float3(3, 3, 3));

            var cubeNode = new SceneNodeContainer();
            cubeNode.Components = new List<SceneComponentContainer>();
            cubeNode.Components.Add(cubeTransform);
            cubeNode.Components.Add(_cubeTransform);
            cubeNode.Components.Add(cubeMaterial);
            cubeNode.Components.Add(cubeMesh);


            SceneNodeContainer []cubeNodeRing = new SceneNodeContainer[20];
            int j;
            int k = 0;

            for (j = 0; j < cubeNodeRing.Length; j++)
            {
                cubeNodeRing[j] = new SceneNodeContainer();
                cubeNodeRing[j].Components = new List<SceneComponentContainer>();
            for (k = k; k == j; k++)
            {
                cubeNodeRing[j].Components.Add(transformArray[k]);
            }            
            // cubeNodeRing[j].Components.Add(_cubeTransform);
            cubeNodeRing[j].Components.Add(cubeMaterialRing);
            cubeNodeRing[j].Components.Add(cubeMeshRing);
            }


            _scene = new SceneContainer();
            _scene.Children = new List<SceneNodeContainer>();
            _scene.Children.Add(cubeNode);

            for (j = 0; j < cubeNodeRing.Length; j++)
            _scene.Children.Add(cubeNodeRing[j]);

            _sceneRenderer = new SceneRenderer(_scene);
        }

        // RenderAFrame is called once a frame
        public override void RenderAFrame()
        {
            // Clear the backbuffer
            RC.Clear(ClearFlags.Color | ClearFlags.Depth);

            // _camAngle = _camAngle + 90.0f * M.Pi/180.0f * DeltaTime;
            _cubeTransform.Translation = new float3(2 * M.Cos(5 * TimeSinceStart) - 3 * M.Cos(4 * (TimeSinceStart)), 2 * M.Cos(4 * TimeSinceStart) - 3 * M.Cos(5 * (TimeSinceStart/2)), 0);
            _cubeTransform.Rotation = new float3(0, M.Sin(2 * TimeSinceStart), 0);
            RC.View = float4x4.CreateTranslation(0, 0, 50) * float4x4.CreateRotationY(_camAngle);
            

            _sceneRenderer.Render(RC);


            // Swap buffers: Show the contents of the backbuffer (containing the currently rendered frame) on the front buffer.
            Present();
        }


        // Is called when the window was resized
        public override void Resize()
        {
            // Set the new rendering area to the entire new windows size
            RC.Viewport(0, 0, Width, Height);

            // Create a new projection matrix generating undistorted images on the new aspect ratio.
            var aspectRatio = Width / (float)Height;

            // 0.25*PI Rad -> 45° Opening angle along the vertical direction. Horizontal opening angle is calculated based on the aspect ratio
            // Front clipping happens at 1 (Objects nearer than 1 world unit get clipped)
            // Back clipping happens at 2000 (Anything further away from the camera than 2000 world units gets clipped, polygons will be cut)
            var projection = float4x4.CreatePerspectiveFieldOfView(M.PiOver4, aspectRatio, 1, 20000);
            RC.Projection = projection;
        }
    }
}