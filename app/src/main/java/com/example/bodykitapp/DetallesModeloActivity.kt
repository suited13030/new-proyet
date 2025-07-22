package com.example.bodykitapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.TextView
import org.json.JSONObject

class DetallesModeloActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_detalles_modelo)

        val modeloId = intent.getIntExtra("modeloId", -1)

        val jsonString = application.assets.open("data.json").bufferedReader().use { it.readText() }
        val jsonObject = JSONObject(jsonString)
        val marcasArray = jsonObject.getJSONArray("marcas")

        for (i in 0 until marcasArray.length()) {
            val marca = marcasArray.getJSONObject(i)
            val modelosArray = marca.getJSONArray("modelos")
            for (j in 0 until modelosArray.length()) {
                val modelo = modelosArray.getJSONObject(j)
                if (modelo.getInt("id") == modeloId) {
                    findViewById<TextView>(R.id.modeloNombre).text = modelo.getString("nombre")
                    findViewById<TextView>(R.id.modeloAño).text = "Año: ${modelo.getInt("año")}"
                    findViewById<TextView>(R.id.modeloMotor).text = "Motor: ${modelo.getString("motor")}"

                    findViewById<Button>(R.id.verBodyKits).setOnClickListener {
                        val intent = Intent(this, BodyKitsActivity::class.java)
                        intent.putExtra("modeloId", modeloId)
                        startActivity(intent)
                    }
                    return
                }
            }
        }
    }
}
