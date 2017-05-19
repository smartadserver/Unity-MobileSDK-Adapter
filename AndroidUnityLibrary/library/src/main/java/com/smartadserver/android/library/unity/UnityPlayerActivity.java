/*
 * This class is inspired by the unity-webview project by Keijiro Takahashi / GREE
 * The complete source code can be found at: https://github.com/gree/unity-webview
 *
 * The original source code is distributed under the zlib license.
 */

package com.smartadserver.android.library.unity;

import android.os.Bundle;
import android.view.Window;

public class UnityPlayerActivity extends com.unity3d.player.UnityPlayerActivity {

    @Override
    public void onCreate(Bundle bundle) {
        requestWindowFeature(Window.FEATURE_NO_TITLE);
        super.onCreate(bundle);
        getWindow().setFormat(Window.FEATURE_NO_TITLE);

        mUnityPlayer = new UnityPlayer(this);
        setContentView(mUnityPlayer);
        mUnityPlayer.requestFocus();
    }

}
