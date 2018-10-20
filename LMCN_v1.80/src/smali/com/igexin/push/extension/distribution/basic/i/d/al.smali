.class Lcom/igexin/push/extension/distribution/basic/i/d/al;
.super Lcom/igexin/push/extension/distribution/basic/i/d/ah;


# direct methods
.method public constructor <init>(Lcom/igexin/push/extension/distribution/basic/i/d/g;)V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/d/ah;-><init>()V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/d/al;->a:Lcom/igexin/push/extension/distribution/basic/i/d/g;

    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/d/al;->a:Lcom/igexin/push/extension/distribution/basic/i/d/g;

    invoke-virtual {v0, p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/d/g;->a(Lcom/igexin/push/extension/distribution/basic/i/b/i;Lcom/igexin/push/extension/distribution/basic/i/b/i;)Z

    move-result v0

    if-nez v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public toString()Ljava/lang/String;
    .locals 4

    const-string v0, ":not%s"

    const/4 v1, 0x1

    new-array v1, v1, [Ljava/lang/Object;

    const/4 v2, 0x0

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/i/d/al;->a:Lcom/igexin/push/extension/distribution/basic/i/d/g;

    aput-object v3, v1, v2

    invoke-static {v0, v1}, Ljava/lang/String;->format(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
