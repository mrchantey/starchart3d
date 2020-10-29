    // no easing, no acceleration
float Linear (float t) { return t;}
    // accelerating from zero velocity
float EaseInQuad (float t) { return t * t;}
    // decelerating to zero velocity
float EaseOutQuad (float t) { return t * (2 - t);}
    // acceleration until halfway, then deceleration
float EaseInOutQuad (float t) { return t < .5 ? 2 * t * t : -1 + (4 - 2 * t) * t;}
    // accelerating from zero velocity 
float EaseInCubic (float t) { return t * t * t;}
    // decelerating to zero velocity 
float EaseOutCubic (float t) { return (--t) * t * t + 1;}
    // acceleration until halfway, then deceleration 
float EaseInOutCubic (float t) { return t < .5 ? 4 * t * t * t : (t - 1) * (2 * t - 2) * (2 * t - 2) + 1;}
    // accelerating from zero velocity 
float EaseInQuart (float t) { return t * t * t * t;}
    // decelerating to zero velocity 
float EaseOutQuart (float t) { return 1 - (--t) * t * t * t;}
    // acceleration until halfway, then deceleration
float EaseInOutQuart (float t) { return t < .5 ? 8 * t * t * t * t : 1 - 8 * (--t) * t * t * t;}
    // accelerating from zero velocity
float EaseInQuint (float t) { return t * t * t * t * t;}
    // decelerating to zero velocity
float EaseOutQuint (float t) { return 1 + (--t) * t * t * t * t;}
    // acceleration until halfway, then deceleration 
float EaseInOutQuint (float t) { return t < .5 ? 16 * t * t * t * t * t : 1 + 16 * (--t) * t * t * t * t; }