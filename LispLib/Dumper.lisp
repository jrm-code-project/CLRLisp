(declare (usual-integrations))

(define file->list
  (lambda (file)
  (call-with-input-file
   file
   (lambda (port)
     (port->list port)))))

(define port->list
    (lambda (port)
    (let ((item (read port)))
      (if (eof-object? item)
          '()
          (cons item (port->list port))))))

(define process-file
  (lambda (infile outfile id)
    (call-with-output-file
     outfile
     (lambda (port)
       (write-string "// Automatically generated.  Don't bother to edit." port) (newline port)
       (newline port)
       (write-string "using LispLib;" port) (newline port)
       (newline port)
       (write-string "class " port) (write-string id port) (newline port)
       (write-string "{" port) (newline port)
       (write-string "    public static List Read () =>" port) (newline port)
       (dump-object (file->list infile) port 8)
       (write-string ";" port) (newline port)
       (write-string "}" port) (newline port)
       ))))

(define indent
  (lambda (indentation stream)
    (unless (zero? indentation)
      (write-char #\Space stream)
      (indent (- indentation 1) stream))))

(define dump-object
  (lambda (object stream indentation)
    (indent indentation stream)
    (cond ((null? object) (write-string "null" stream))
          ((char? object) (dump-char object stream))
          ((list? object) (dump-list object stream indentation))
          ((number? object) (write object stream))
          ((string? object) (dump-string object stream))
          ((symbol? object) (dump-symbol object stream))
          (else (error "Can't dump: " object)))))

(define dump-char
  (lambda (char stream)
    (write-string "'" stream)
    (write-char char stream)
    (write-string "'" stream)))

(define dump-list
  (lambda (list stream indentation)
    (write-string "new List (" stream)
    (newline stream)
    (if (null? list)
        (write-string ")" stream)
        (let loop ((head (car list))
                   (tail (cdr list)))
             (if (null? tail)
                 (begin
                  (dump-object head stream (+ indentation 4))
                  (write-string ")" stream))
                 (begin
                  (dump-object head stream (+ indentation 4))
                  (write-string "," stream)
                  (newline stream)
                  (loop (car tail) (cdr tail))))))))

(define dump-string
  (lambda (string stream)
    (write-char #\" stream)
    (write-string string stream)
    (write-char #\" stream)))

(define dump-symbol
  (lambda (symbol stream)
    (write-string "Symbol.Intern (" stream)
    (write-char #\" stream)
    (write-string (symbol-name symbol) stream)
    (write-char #\" stream)
    (write-string ")" stream)))
