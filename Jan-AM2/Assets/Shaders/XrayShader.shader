// this will be applied to any INVISIBLE OBJECTS that will make objets transparent
Shader "Custom/XrayShader"
{
    
    SubShader
    {
        Tags {"Queue" = "Transparent+1"}        // renders after all transparent object (queue = 3001)
        Pass {Blend Zero One}                   // makes the object transparent
    }
    
}
