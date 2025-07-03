// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Kopyala butonu animasyonu
function copyToClipboard(id) {
    var copyText = document.getElementById(id);
    copyText.select();
    copyText.setSelectionRange(0, 99999);
    document.execCommand("copy");
    var btns = document.querySelectorAll('[onclick*="copyToClipboard(\'' + id + '\')"]');
    btns.forEach(function(btn) {
        btn.classList.add('copied');
        setTimeout(function() { btn.classList.remove('copied'); }, 800);
    });
}

// Dosya inputunda dosya adını göster
window.addEventListener('DOMContentLoaded', function() {
    var fileInputs = document.querySelectorAll('input[type="file"]');
    fileInputs.forEach(function(input) {
        input.addEventListener('change', function(e) {
            var label = document.createElement('span');
            label.className = 'file-name';
            label.style = 'color:#00ff99; margin-left:10px; font-size:0.95em;';
            if (input.files.length > 0) {
                label.textContent = input.files[0].name;
            } else {
                label.textContent = '';
            }
            if (input.nextSibling) input.parentNode.removeChild(input.nextSibling);
            input.parentNode.appendChild(label);
        });
    });
});

// Form sonrası input temizleme (sadece hash ve şifreleme formları için örnek)
window.addEventListener('DOMContentLoaded', function() {
    var forms = document.querySelectorAll('form');
    forms.forEach(function(form) {
        form.addEventListener('submit', function(e) {
            setTimeout(function() {
                var inputs = form.querySelectorAll('input[type="text"], textarea');
                inputs.forEach(function(inp) { inp.value = ''; });
                var fileInputs = form.querySelectorAll('input[type="file"]');
                fileInputs.forEach(function(inp) { inp.value = ''; });
            }, 500);
        });
    });
});

// Butonlara yükleniyor animasyonu
window.addEventListener('DOMContentLoaded', function() {
    var forms = document.querySelectorAll('form');
    forms.forEach(function(form) {
        form.addEventListener('submit', function(e) {
            var btn = form.querySelector('button[type="submit"]');
            if(btn) {
                btn.classList.add('loading');
                btn.disabled = true;
                setTimeout(function() {
                    btn.classList.remove('loading');
                    btn.disabled = false;
                }, 1200);
            }
        });
    });
});

// Başarı mesajı (örnek: hash veya şifreleme sonrası)
window.addEventListener('DOMContentLoaded', function() {
    var alerts = document.querySelectorAll('.alert');
    if(alerts.length > 0) {
        var success = document.createElement('div');
        success.className = 'alert';
        success.style.background = 'rgba(0,32,0,0.8)';
        success.style.borderColor = '#00ff99';
        success.style.position = 'fixed';
        success.style.top = '24px';
        success.style.left = '50%';
        success.style.transform = 'translateX(-50%)';
        success.style.zIndex = '9999';
        success.innerHTML = '<i class="fas fa-check-circle"></i> Başarıyla oluşturuldu!';
        document.body.appendChild(success);
        setTimeout(function() { success.remove(); }, 1800);
    }
});

// Klavye kısayolu: Ctrl+B ile hash kopyala
window.addEventListener('keydown', function(e) {
    if((e.ctrlKey || e.metaKey) && e.key.toLowerCase() === 'b') {
        var hashArea = document.getElementById('sha512hash');
        if(hashArea) {
            hashArea.select();
            document.execCommand('copy');
            var btns = document.querySelectorAll('[onclick*="copyToClipboard(\'sha512hash\')"]');
            btns.forEach(function(btn) {
                btn.classList.add('copied');
                setTimeout(function() { btn.classList.remove('copied'); }, 800);
            });
        }
    }
});

