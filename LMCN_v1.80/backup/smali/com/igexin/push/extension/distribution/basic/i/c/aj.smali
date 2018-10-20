.class Lcom/igexin/push/extension/distribution/basic/i/c/aj;
.super Lcom/igexin/push/extension/distribution/basic/i/c/af;


# instance fields
.field final b:Ljava/lang/StringBuilder;

.field final c:Ljava/lang/StringBuilder;

.field final d:Ljava/lang/StringBuilder;

.field e:Z


# direct methods
.method constructor <init>()V
    .locals 1

    const/4 v0, 0x0

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/i/c/af;-><init>(Lcom/igexin/push/extension/distribution/basic/i/c/ag;)V

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->b:Ljava/lang/StringBuilder;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->c:Ljava/lang/StringBuilder;

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->d:Ljava/lang/StringBuilder;

    const/4 v0, 0x0

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->e:Z

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    return-void
.end method


# virtual methods
.method m()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->b:Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method n()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->c:Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public o()Ljava/lang/String;
    .locals 1

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->d:Ljava/lang/StringBuilder;

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method

.method public p()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/aj;->e:Z

    return v0
.end method
