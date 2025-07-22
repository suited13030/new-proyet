package com.example.bodykitapp

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ArrayAdapter
import android.widget.ListView
import org.json.JSONObject

class BodyKitsActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_body_kits)

        val modeloId = intent.getIntExtra("modeloId", -1)
        val listView = findViewById<ListView>(R.id.listView)
        val bodyKits = mutableListOf<String>()
        val bodyKitIds = mutableListOf<Int>()

        val jsonString = application.assets.open("data.json").bufferedReader().use { it.readText() }
        val jsonObject = JSONObject(jsonString)
        val marcasArray = jsonObject.getJSONArray("marcas")

        for (i in 0 until marcasArray.length()) {
            val marca = marcasArray.getJSONObject(i)
            val modelosArray = marca.getJSONArray("modelos")
            for (j in 0 until modelosArray.length()) {
                val modelo = modelosArray.getJSONObject(j)
                if (modelo.getInt("id") == modeloId) {
                    val bodyKitsArray = modelo.getJSONArray("body_kits")
                    for (k in 0 until bodyKitsArray.length()) {
                        val bodyKit = bodyKitsArray.getJSONObject(k)
                        bodyKits.add(bodyKit.getString("nombre"))
                        bodyKitIds.add(bodyKit.getInt("id"))
                    }
                    break
                }
            }
        }

        val adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, bodyKits)
        listView.adapter = adapter

        listView.setOnItemClickListener { _, _, position, _ ->
            val intent = Intent(this, DetallesBodyKitActivity::class.java)
            intent.putExtra("bodyKitId", bodyKitIds[position])
            startActivity(intent)
        }
    }
}
