# Ahoy

Core framework for improving Unity workflow. This library implements game architecture shared by Ryan Hipple of Schell Games as given in [this talk](https://youtu.be/raQ3iHhE_Kk) and [gitHub](https://github.com/roboryantron/Unite2017)

### Procedural Scripts

Procedural scripts exist for the following types:
- bool
- byte
- color24
- float
- GameObject
- Image2D
- int
- KeyCode
- object
- Pose
- Quaternion
- String
- Texture2D
- Vector2
- Vector3
- Vector4
  
For each of these types the following classes are generated:
- Events
  - UnityEvent
  - ArrayUnityEvent
  - ListUnityEvent
- AssetEvent
- AssetEventListener
- InvocableMono
- ArrayInvocableMono
- TimeThrottle
- ArrayTimeThrottle
