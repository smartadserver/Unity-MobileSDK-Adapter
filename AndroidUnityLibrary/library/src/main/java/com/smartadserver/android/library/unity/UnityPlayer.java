/*
 * This class is inspired by the unity-webview project by Keijiro Takahashi / GREE
 * The complete source code can be found at: https://github.com/gree/unity-webview
 *
 * The original source code is distributed under the zlib license.
 */

package com.smartadserver.android.library.unity;

import android.annotation.SuppressLint;
import android.content.ContextWrapper;
import android.view.SurfaceView;
import android.view.View;

@SuppressLint("ViewConstructor")
class UnityPlayer extends com.unity3d.player.UnityPlayer {

    public UnityPlayer(ContextWrapper contextwrapper) {
        super(contextwrapper);
    }

    public void addView(View child) {
        if (child instanceof SurfaceView) {
            ((SurfaceView) child).setZOrderOnTop(false);
        }
        super.addView(child);
    }

}
