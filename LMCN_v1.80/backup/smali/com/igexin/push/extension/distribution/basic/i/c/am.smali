.class Lcom/igexin/push/extension/distribution/basic/i/c/am;
.super Lcom/igexin/push/extension/distribution/basic/i/c/an;


# direct methods
.method constructor <init>()V
    .locals 1

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/an;-><init>()V

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/i/c/ao;->b:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/i/c/am;->a:Lcom/igexin/push/extension/distribution/basic/i/c/ao;

    return-void
.end method

.method constructor <init>(Ljava/lang/String;)V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>()V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/am;->b:Ljava/lang/String;

    return-void
.end method

.method constructor <init>(Ljava/lang/String;Lcom/igexin/push/extension/distribution/basic/i/b/b;)V
    .locals 0

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/am;-><init>()V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/am;->b:Ljava/lang/String;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/i/c/am;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    return-void
.end method


# virtual methods
.method public toString()Ljava/lang/String;
    .locals 2

    new-instance v0, Ljava/lang/StringBuilder;

    invoke-direct {v0}, Ljava/lang/StringBuilder;-><init>()V

    const-string v1, "<"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {p0}, Lcom/igexin/push/extension/distribution/basic/i/c/am;->o()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, " "

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/i/c/am;->d:Lcom/igexin/push/extension/distribution/basic/i/b/b;

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/b/b;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    const-string v1, ">"

    invoke-virtual {v0, v1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
