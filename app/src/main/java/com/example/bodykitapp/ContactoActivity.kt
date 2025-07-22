package com.example.bodykitapp

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast

class ContactoActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_contacto)

        val nombre = findViewById<EditText>(R.id.nombre)
        val email = findViewById<EditText>(R.id.email)
        val mensaje = findViewById<EditText>(R.id.mensaje)

        findViewById<Button>(R.id.enviar).setOnClickListener {
            Toast.makeText(this, "Formulario enviado", Toast.LENGTH_SHORT).show()
            nombre.text.clear()
            email.text.clear()
            mensaje.text.clear()
        }
    }
}
