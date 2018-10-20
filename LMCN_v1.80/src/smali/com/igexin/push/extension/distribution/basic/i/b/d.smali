.class public Lcom/igexin/push/extension/distribution/basic/i/b/d;
.super Lcom/igexin/push/extension/distribution/basic/i/b/l;


# direct methods
.method public constructor <init>(Ljava/lang/String;Ljava/lang/String;)V
    .locals 2

    invoke-direct {p0, p2}, Lcom/igexin/push/extension/distribution/basic/i/b/l;-><init>(Ljava/lang/String;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/d;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    const-string v1, "data"

    invoke-virtual {v0, v1, p1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Ljava/lang/String;Ljava/lang/String;)V

    return-void
.end method


# virtual methods
.method public a()Ljava/lang/String;
    .locals 1

    const-string v0, "#data"

    return-object v0
.end method

.method a(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/d;->b()Ljava/lang/String;

    move-result-object v0

    invoke-virtual {p1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    return-void
.end method

.method public b()Ljava/lang/String;
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/d;->c:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    const-string v1, "data"

    invoke-virtual {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method b(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V
    .locals 0

    return-void
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/b/d;->d_()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
