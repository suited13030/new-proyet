package com.example.bodykitapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.ListView
import org.json.JSONObject

class ModelosActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_modelos)

        val marcaId = intent.getIntExtra("marcaId", -1)
        val listView = findViewById<ListView>(R.id.listView)
        val modelos = mutableListOf<String>()
        val modeloIds = mutableListOf<Int>()

        val jsonString = application.assets.open("data.json").bufferedReader().use { it.readText() }
        val jsonObject = JSONObject(jsonString)
        val marcasArray = jsonObject.getJSONArray("marcas")

        for (i in 0 until marcasArray.length()) {
            val marca = marcasArray.getJSONObject(i)
            if (marca.getInt("id") == marcaId) {
                val modelosArray = marca.getJSONArray("modelos")
                for (j in 0 until modelosArray.length()) {
                    val modelo = modelosArray.getJSONObject(j)
                    modelos.add(modelo.getString("nombre"))
                    modeloIds.add(modelo.getInt("id"))
                }
                break
            }
        }

        val adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, modelos)
        listView.adapter = adapter

        listView.setOnItemClickListener { _, _, position, _ ->
            val intent = Intent(this, DetallesModeloActivity::class.java)
            intent.putExtra("modeloId", modeloIds[position])
            startActivity(intent)
        }
    }
}
