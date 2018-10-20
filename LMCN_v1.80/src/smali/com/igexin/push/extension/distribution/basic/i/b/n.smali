.class Lcom/igexin/push/extension/distribution/basic/i/b/n;
.super Ljava/lang/Object;

# interfaces
.implements Lcom/igexin/push/extension/distribution/basic/i/d/ad;


# instance fields
.field private a:Ljava/lang/StringBuilder;

.field private b:Lcom/igexin/push/extension/distribution/basic/i/b/f;


# direct methods
.method constructor <init>(Ljava/lang/StringBuilder;Lcom/igexin/push/extension/distribution/basic/i/b/f;)V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/n;->a:Ljava/lang/StringBuilder;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/i/b/n;->b:Lcom/igexin/push/extension/distribution/basic/i/b/f;

    return-void
.end method


# virtual methods
.method public a(Lcom/igexin/push/extension/distribution/basic/i/b/l;I)V
    .locals 2

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/n;->a:Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/n;->b:Lcom/igexin/push/extension/distribution/basic/i/b/f;

    invoke-virtual {p1, v0, p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V

    return-void
.end method

.method public b(Lcom/igexin/push/extension/distribution/basic/i/b/l;I)V
    .locals 2

    invoke-virtual {p1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->a()Ljava/lang/String;

    move-result-object v0

    const-string v1, "#text"

    invoke-virtual {v0, v1}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_0

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/b/n;->a:Ljava/lang/StringBuilder;

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/b/n;->b:Lcom/igexin/push/extension/distribution/basic/i/b/f;

    invoke-virtual {p1, v0, p2, v1}, Lcom/igexin/push/extension/distribution/basic/i/b/l;->b(Ljava/lang/StringBuilder;ILcom/igexin/push/extension/distribution/basic/i/b/f;)V

    :cond_0
    return-void
.end method
