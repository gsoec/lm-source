.class public Lcom/igexin/push/extension/distribution/basic/i/a/a;
.super Ljava/lang/Object;


# static fields
.field private static final a:Ljava/util/regex/Pattern;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    const-string v0, "(?i)\\bcharset=\\s*\"?([^\\s;\"]*)"

    invoke-static {v0}, Ljava/util/regex/Pattern;->compile(Ljava/lang/String;)Ljava/util/regex/Pattern;

    move-result-object v0

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/i/a/a;->a:Ljava/util/regex/Pattern;

    return-void
.end method

.method static a(Ljava/nio/ByteBuffer;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/c/ad;)Lcom/igexin/push/extension/distribution/basic/i/b/e;
    .locals 6

    const/4 v0, 0x0

    if-nez p1, :cond_2

    const-string v1, "UTF-8"

    invoke-static {v1}, Ljava/nio/charset/Charset;->forName(Ljava/lang/String;)Ljava/nio/charset/Charset;

    move-result-object v1

    invoke-virtual {v1, p0}, Ljava/nio/charset/Charset;->decode(Ljava/nio/ByteBuffer;)Ljava/nio/CharBuffer;

    move-result-object v1

    invoke-virtual {v1}, Ljava/nio/CharBuffer;->toString()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {p3, v2, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/ad;->a(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v1

    const-string v3, "meta[http-equiv=content-type], meta[charset]"

    invoke-virtual {v1, v3}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/d/f;

    move-result-object v3

    invoke-virtual {v3}, Lcom/igexin/push/extension/distribution/basic/i/d/f;->c()Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v3

    if-eqz v3, :cond_4

    const-string v4, "http-equiv"

    invoke-virtual {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->e(Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_1

    const-string v4, "content"

    invoke-virtual {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->d(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    invoke-static {v3}, Lcom/igexin/push/extension/distribution/basic/i/a/a;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    :goto_0
    if-eqz v3, :cond_4

    invoke-virtual {v3}, Ljava/lang/String;->length()I

    move-result v4

    if-eqz v4, :cond_4

    const-string v4, "UTF-8"

    invoke-virtual {v3, v4}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v4

    if-nez v4, :cond_4

    invoke-virtual {p0}, Ljava/nio/ByteBuffer;->rewind()Ljava/nio/Buffer;

    invoke-static {v3}, Ljava/nio/charset/Charset;->forName(Ljava/lang/String;)Ljava/nio/charset/Charset;

    move-result-object v1

    invoke-virtual {v1, p0}, Ljava/nio/charset/Charset;->decode(Ljava/nio/ByteBuffer;)Ljava/nio/CharBuffer;

    move-result-object v1

    invoke-virtual {v1}, Ljava/nio/CharBuffer;->toString()Ljava/lang/String;

    move-result-object v1

    move-object p1, v3

    :goto_1
    move-object v5, v0

    move-object v0, v1

    move-object v1, v5

    :goto_2
    if-nez v1, :cond_3

    const/4 v1, 0x0

    invoke-virtual {v0, v1}, Ljava/lang/String;->charAt(I)C

    move-result v1

    const v2, 0xfeff

    if-ne v1, v2, :cond_0

    const/4 v1, 0x1

    invoke-virtual {v0, v1}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v0

    :cond_0
    invoke-virtual {p3, v0, p2}, Lcom/igexin/push/extension/distribution/basic/i/c/ad;->a(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->d()Lcom/igexin/push/extension/distribution/basic/i/b/f;

    move-result-object v1

    invoke-virtual {v1, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/f;

    :goto_3
    return-object v0

    :cond_1
    const-string v4, "charset"

    invoke-virtual {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->d(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v3

    goto :goto_0

    :cond_2
    const-string v1, "Must set charset arg to character set of file to parse. Set to null to attempt to detect from HTML"

    invoke-static {p1, v1}, Lcom/igexin/push/extension/distribution/basic/i/a/k;->a(Ljava/lang/String;Ljava/lang/String;)V

    invoke-static {p1}, Ljava/nio/charset/Charset;->forName(Ljava/lang/String;)Ljava/nio/charset/Charset;

    move-result-object v1

    invoke-virtual {v1, p0}, Ljava/nio/charset/Charset;->decode(Ljava/nio/ByteBuffer;)Ljava/nio/CharBuffer;

    move-result-object v1

    invoke-virtual {v1}, Ljava/nio/CharBuffer;->toString()Ljava/lang/String;

    move-result-object v1

    move-object v5, v0

    move-object v0, v1

    move-object v1, v5

    goto :goto_2

    :cond_3
    move-object v0, v1

    goto :goto_3

    :cond_4
    move-object v0, v1

    move-object v1, v2

    goto :goto_1
.end method

.method static a(Ljava/lang/String;)Ljava/lang/String;
    .locals 3

    const/4 v0, 0x0

    if-nez p0, :cond_1

    :cond_0
    :goto_0
    return-object v0

    :cond_1
    sget-object v1, Lcom/igexin/push/extension/distribution/basic/i/a/a;->a:Ljava/util/regex/Pattern;

    invoke-virtual {v1, p0}, Ljava/util/regex/Pattern;->matcher(Ljava/lang/CharSequence;)Ljava/util/regex/Matcher;

    move-result-object v1

    invoke-virtual {v1}, Ljava/util/regex/Matcher;->find()Z

    move-result v2

    if-eqz v2, :cond_0

    const/4 v0, 0x1

    invoke-virtual {v1, v0}, Ljava/util/regex/Matcher;->group(I)Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->trim()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/String;->toUpperCase()Ljava/lang/String;

    move-result-object v0

    goto :goto_0
.end method

.method static a(Ljava/io/InputStream;)Ljava/nio/ByteBuffer;
    .locals 4

    const/high16 v2, 0x20000

    new-array v0, v2, [B

    new-instance v1, Ljava/io/ByteArrayOutputStream;

    invoke-direct {v1, v2}, Ljava/io/ByteArrayOutputStream;-><init>(I)V

    :goto_0
    invoke-virtual {p0, v0}, Ljava/io/InputStream;->read([B)I

    move-result v2

    const/4 v3, -0x1

    if-ne v2, v3, :cond_0

    invoke-virtual {v1}, Ljava/io/ByteArrayOutputStream;->toByteArray()[B

    move-result-object v0

    invoke-static {v0}, Ljava/nio/ByteBuffer;->wrap([B)Ljava/nio/ByteBuffer;

    move-result-object v0

    return-object v0

    :cond_0
    const/4 v3, 0x0

    invoke-virtual {v1, v0, v3, v2}, Ljava/io/ByteArrayOutputStream;->write([BII)V

    goto :goto_0
.end method
