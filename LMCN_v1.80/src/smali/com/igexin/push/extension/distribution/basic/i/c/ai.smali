.class Lcom/igexin/push/extension/distribution/basic/i/c/ai;
.super Lcom/igexin/push/extension/distribution/basic/i/c/af;


# instance fields
.field final b:Ljava/lang/StringBuilder;


# direct methods
.method constructor <init>()V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/af;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/ag;)V

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ai;->b:Ljava/lang/StringBuilder;

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->d:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ai;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    return-void
.end method


# virtual methods
.method m()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/ai;->b:Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public toString()Ljava/lang/String;
    .locals 2

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "<!--"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/ai;->m()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, "-->"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
