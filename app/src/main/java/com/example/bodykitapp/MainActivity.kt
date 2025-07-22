package com.example.bodykitapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.ListView
import org.json.JSONObject

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val listView = findViewById<ListView>(R.id.listView)
        val marcas = mutableListOf<String>()
        val marcaIds = mutableListOf<Int>()

        val jsonString = application.assets.open("data.json").bufferedReader().use { it.readText() }
        val jsonObject = JSONObject(jsonString)
        val marcasArray = jsonObject.getJSONArray("marcas")

        for (i in 0 until marcasArray.length()) {
            val marca = marcasArray.getJSONObject(i)
            marcas.add(marca.getString("nombre"))
            marcaIds.add(marca.getInt("id"))
        }

        val adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, marcas)
        listView.adapter = adapter

        listView.setOnItemClickListener { _, _, position, _ ->
            val intent = Intent(this, ModelosActivity::class.java)
            intent.putExtra("marcaId", marcaIds[position])
            startActivity(intent)
        }
    }
}
