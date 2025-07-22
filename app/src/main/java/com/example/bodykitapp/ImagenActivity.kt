package com.example.bodykitapp

import android.graphics.drawable.Drawable
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ImageView
import java.io.InputStream

class ImagenActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_imagen)

        val imagenNombre = intent.getStringExtra("imagen")
        val imageView = findViewById<ImageView>(R.id.imageView)

        try {
            val ims: InputStream = assets.open(imagenNombre!!)
            val d = Drawable.createFromStream(ims, null)
            imageView.setImageDrawable(d)
        } catch (e: Exception) {
            e.printStackTrace()
        }
    }
}
