package com.example.bodykitapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import org.json.JSONObject

class DetallesBodyKitActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_detalles_body_kit)

        val bodyKitId = intent.getIntExtra("bodyKitId", -1)

        val jsonString = application.assets.open("data.json").bufferedReader().use { it.readText() }
        val jsonObject = JSONObject(jsonString)
        val marcasArray = jsonObject.getJSONArray("marcas")

        for (i in 0 until marcasArray.length()) {
            val marca = marcasArray.getJSONObject(i)
            val modelosArray = marca.getJSONArray("modelos")
            for (j in 0 until modelosArray.length()) {
                val modelo = modelosArray.getJSONObject(j)
                val bodyKitsArray = modelo.getJSONArray("body_kits")
                for (k in 0 until bodyKitsArray.length()) {
                    val bodyKit = bodyKitsArray.getJSONObject(k)
                    if (bodyKit.getInt("id") == bodyKitId) {
                        findViewById<TextView>(R.id.kitNombre).text = bodyKit.getString("nombre")
                        findViewById<TextView>(R.id.kitPrecio).text = "Precio: ${bodyKit.getString("precio")}"
                        findViewById<TextView>(R.id.kitMateriales).text = "Materiales: ${bodyKit.getString("materiales")}"

                        findViewById<Button>(R.id.verImagen).setOnClickListener {
                            val intent = Intent(this, ImagenActivity::class.java)
                            intent.putExtra("imagen", bodyKit.getString("imagen"))
                            startActivity(intent)
                        }
                        return
                    }
                }
            }
        }
    }
}
