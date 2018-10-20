.class public Lcom/igexin/push/extension/distribution/basic/i/b/f;
.super Ljava/lang/Object;

# interfaces
.implements Ljava/lang/Cloneable;


# instance fields
.field private a:Lcom/igexin/push/extension/distribution/basic/i/b/k;

.field private b:Ljava/nio/charset/Charset;

.field private c:Ljava/nio/charset/CharsetEncoder;

.field private d:Z

.field private e:I


# direct methods
.method public constructor <init>()V
    .locals 2

    const/4 v1, 0x1

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/b/k;->b:Lcom/igexin/push/extension/distribution/basic/i/b/k;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->a:Lcom/igexin/push/extension/distribution/basic/i/b/k;

    const-string v0, "UTF-8"

    invoke-static {v0}, Ljava/nio/charset/Charset;->forName(Ljava/lang/String;)Ljava/nio/charset/Charset;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->b:Ljava/nio/charset/Charset;

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->b:Ljava/nio/charset/Charset;

    invoke-virtual {v0}, Ljava/nio/charset/Charset;->newEncoder()Ljava/nio/charset/CharsetEncoder;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->c:Ljava/nio/charset/CharsetEncoder;

    iput-boolean v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->d:Z

    iput v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->e:I

    return-void
.end method


# virtual methods
.method public a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/f;
    .locals 1

    invoke-static {p1}, Ljava/nio/charset/Charset;->forName(Ljava/lang/String;)Ljava/nio/charset/Charset;

    move-result-object v0

    invoke-virtual {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->a(Ljava/nio/charset/Charset;)Lcom/igexin/push/extension/distribution/basic/i/b/f;

    return-object p0
.end method

.method public a(Ljava/nio/charset/Charset;)Lcom/igexin/push/extension/distribution/basic/i/b/f;
    .locals 1

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->b:Ljava/nio/charset/Charset;

    invoke-virtual {p1}, Ljava/nio/charset/Charset;->newEncoder()Ljava/nio/charset/CharsetEncoder;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->c:Ljava/nio/charset/CharsetEncoder;

    return-object p0
.end method

.method public a()Lcom/igexin/push/extension/distribution/basic/i/b/k;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->a:Lcom/igexin/push/extension/distribution/basic/i/b/k;

    return-object v0
.end method

.method public b()Ljava/nio/charset/Charset;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->b:Ljava/nio/charset/Charset;

    return-object v0
.end method

.method c()Ljava/nio/charset/CharsetEncoder;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->c:Ljava/nio/charset/CharsetEncoder;

    return-object v0
.end method

.method public synthetic clone()Ljava/lang/Object;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->f()Lcom/igexin/push/extension/distribution/basic/i/b/f;

    move-result-object v0

    return-object v0
.end method

.method public d()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->d:Z

    return v0
.end method

.method public e()I
    .locals 1

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->e:I

    return v0
.end method

.method public f()Lcom/igexin/push/extension/distribution/basic/i/b/f;
    .locals 2

    :try_start_0
    invoke-super {p0}, Ljava/lang/Object;->clone()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/i/b/f;
    :try_end_0
    .catch Ljava/lang/CloneNotSupportedException; {:try_start_0 .. :try_end_0} :catch_0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->b:Ljava/nio/charset/Charset;

    invoke-virtual {v1}, Ljava/nio/charset/Charset;->name()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/f;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/f;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->a:Lcom/igexin/push/extension/distribution/basic/i/b/k;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/k;->name()Ljava/lang/String;

    move-result-object v1

    invoke-static {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/k;->a(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/k;

    move-result-object v1

    iput-object v1, v0, Lcom/igexin/push/extension/distribution/basic/i/b/f;->a:Lcom/igexin/push/extension/distribution/basic/i/b/k;

    return-object v0

    :catch_0
    move-exception v0

    new-instance v1, Ljava/lang/RuntimeException;

    invoke-direct {v1, v0}, Ljava/lang/RuntimeException;-><init>(Ljava/lang/Throwable;)V

    throw v1
.end method
