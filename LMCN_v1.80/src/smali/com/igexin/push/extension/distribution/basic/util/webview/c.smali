.class Lcom/igexin/push/extension/distribution/basic/util/webview/c;
.super Lcom/igexin/b/a/d/d;


# instance fields
.field a:Ljava/lang/String;

.field b:Ljava/io/File;

.field c:Ljava/lang/String;

.field d:Ljava/util/Queue;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/Queue",
            "<",
            "Lcom/igexin/push/extension/distribution/basic/util/webview/a;",
            ">;"
        }
    .end annotation
.end field

.field e:I


# direct methods
.method constructor <init>(Ljava/lang/String;Ljava/lang/String;ILjava/io/File;)V
    .locals 1

    invoke-direct {p0, p3}, Lcom/igexin/b/a/d/d;-><init>(I)V

    const/4 v0, 0x1

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->e:I

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->a:Ljava/lang/String;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->c:Ljava/lang/String;

    iput-object p4, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->b:Ljava/io/File;

    return-void
.end method

.method private a(Ljava/lang/String;)Ljava/lang/String;
    .locals 4

    const/16 v0, 0x2f

    invoke-virtual {p1, v0}, Ljava/lang/String;->lastIndexOf(I)I

    move-result v0

    add-int/lit8 v0, v0, 0x1

    if-lez v0, :cond_2

    invoke-virtual {p1, v0}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v1

    const-string v0, ""

    const/16 v2, 0x2e

    invoke-virtual {v1, v2}, Ljava/lang/String;->lastIndexOf(I)I

    move-result v2

    add-int/lit8 v2, v2, 0x1

    if-ltz v2, :cond_0

    const/16 v0, 0x3f

    invoke-virtual {v1, v0, v2}, Ljava/lang/String;->indexOf(II)I

    move-result v0

    if-ltz v0, :cond_1

    invoke-virtual {v1, v2, v0}, Ljava/lang/String;->substring(II)Ljava/lang/String;

    move-result-object v0

    :cond_0
    :goto_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    iget v2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->e:I

    add-int/lit8 v3, v2, 0x1

    iput v3, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->e:I

    invoke-static {v2}, Ljava/lang/String;->valueOf(I)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "_"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "res/"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v0

    invoke-virtual {v0}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    :goto_1
    return-object v0

    :cond_1
    invoke-virtual {v1, v2}, Ljava/lang/String;->substring(I)Ljava/lang/String;

    move-result-object v0

    goto :goto_0

    :cond_2
    const/4 v0, 0x0

    goto :goto_1
.end method

.method private a(Lcom/igexin/push/extension/distribution/basic/i/b/e;)V
    .locals 6

    const-string v0, "meta"

    invoke-virtual {p1, v0}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->b(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/d/f;

    move-result-object v1

    const/4 v0, 0x0

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/d/f;->size()I

    move-result v2

    :goto_0
    if-ge v0, v2, :cond_1

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/f;->a(I)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v3

    const-string v4, "content"

    invoke-virtual {v3, v4}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->e(Ljava/lang/String;)Z

    move-result v4

    if-eqz v4, :cond_0

    const-string v4, "content"

    const-string v5, "text/html;charset=utf-8"

    invoke-virtual {v3, v4, v5}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    :cond_0
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    return-void
.end method

.method private a(Lcom/igexin/push/extension/distribution/basic/i/b/e;Ljava/lang/String;Ljava/lang/String;)V
    .locals 7

    invoke-virtual {p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->b(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/d/f;

    move-result-object v1

    const/4 v0, 0x0

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/d/f;->size()I

    move-result v2

    :goto_0
    if-ge v0, v2, :cond_2

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/f;->a(I)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v3

    invoke-virtual {v3, p3}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->d(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    if-nez v4, :cond_1

    :cond_0
    :goto_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    invoke-virtual {v3, p3}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->g(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    invoke-direct {p0, v4}, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->a(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    if-eqz v5, :cond_0

    invoke-virtual {v3, p3, v5}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    new-instance v3, Ljava/lang/StringBuilder;

    invoke-direct {v3}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v6, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->b:Ljava/io/File;

    invoke-virtual {v6}, Ljava/io/File;->getAbsolutePath()Ljava/lang/String;

    move-result-object v6

    invoke-virtual {v3, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    const-string v6, "/"

    invoke-virtual {v3, v6}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3, v5}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v3

    invoke-virtual {v3}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v3

    iget-object v5, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->d:Ljava/util/Queue;

    new-instance v6, Lcom/igexin/push/extension/distribution/basic/util/webview/a;

    invoke-direct {v6, v3, v4}, Lcom/igexin/push/extension/distribution/basic/util/webview/a;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    invoke-interface {v5, v6}, Ljava/util/Queue;->add(Ljava/lang/Object;)Z

    goto :goto_1

    :cond_2
    return-void
.end method

.method private b(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/e;
    .locals 2

    :try_start_0
    new-instance v0, Ljava/net/URL;

    invoke-direct {v0, p1}, Ljava/net/URL;-><init>(Ljava/lang/String;)V

    const v1, 0xea60

    invoke-static {v0, v1}, Lcom/igexin/push/extension/distribution/basic/i/g;->a(Ljava/net/URL;I)Lcom/igexin/push/extension/distribution/basic/i/b/e;
    :try_end_0
    .catch Ljava/lang/Exception; {:try_start_0 .. :try_end_0} :catch_0

    move-result-object v0

    :goto_0
    return-object v0

    :catch_0
    move-exception v0

    const/4 v0, 0x0

    goto :goto_0
.end method

.method private b(Lcom/igexin/push/extension/distribution/basic/i/b/e;Ljava/lang/String;Ljava/lang/String;)V
    .locals 6

    invoke-virtual {p1, p2}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->b(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/d/f;

    move-result-object v1

    const/4 v0, 0x0

    invoke-virtual {v1}, Lcom/igexin/push/extension/distribution/basic/i/d/f;->size()I

    move-result v2

    :goto_0
    if-ge v0, v2, :cond_2

    invoke-virtual {v1, v0}, Lcom/igexin/push/extension/distribution/basic/i/d/f;->a(I)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    move-result-object v3

    invoke-virtual {v3, p3}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->d(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v4

    if-eqz v4, :cond_0

    const-string v5, "javascript:"

    invoke-virtual {v4, v5}, Ljava/lang/String;->startsWith(Ljava/lang/String;)Z

    move-result v5

    if-eqz v5, :cond_1

    :cond_0
    :goto_1
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    :cond_1
    invoke-virtual {v3, p3}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->g(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v5

    if-eq v5, v4, :cond_0

    invoke-virtual {v3, p3, v5}, Lcom/igexin/push/extension/distribution/basic/i/b/i;->a(Ljava/lang/String;Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/i;

    goto :goto_1

    :cond_2
    return-void
.end method

.method private g()Ljava/lang/String;
    .locals 3

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->c:Ljava/lang/String;

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->b(Ljava/lang/String;)Lcom/igexin/push/extension/distribution/basic/i/b/e;

    move-result-object v0

    if-eqz v0, :cond_0

    new-instance v1, Ljava/util/LinkedList;

    invoke-direct {v1}, Ljava/util/LinkedList;-><init>()V

    iput-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->d:Ljava/util/Queue;

    const-string v1, "link"

    const-string v2, "href"

    invoke-direct {p0, v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->a(Lcom/igexin/push/extension/distribution/basic/i/b/e;Ljava/lang/String;Ljava/lang/String;)V

    const-string v1, "img"

    const-string v2, "src"

    invoke-direct {p0, v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->a(Lcom/igexin/push/extension/distribution/basic/i/b/e;Ljava/lang/String;Ljava/lang/String;)V

    const-string v1, "script"

    const-string v2, "src"

    invoke-direct {p0, v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->a(Lcom/igexin/push/extension/distribution/basic/i/b/e;Ljava/lang/String;Ljava/lang/String;)V

    const-string v1, "a"

    const-string v2, "href"

    invoke-direct {p0, v0, v1, v2}, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->b(Lcom/igexin/push/extension/distribution/basic/i/b/e;Ljava/lang/String;Ljava/lang/String;)V

    invoke-direct {p0, v0}, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->a(Lcom/igexin/push/extension/distribution/basic/i/b/e;)V

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/i/b/e;->d_()Ljava/lang/String;

    move-result-object v0

    return-object v0

    :cond_0
    new-instance v0, Ljava/io/IOException;

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    const-string v2, "getDocumentByUrl failed: "

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->c:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-direct {v0, v1}, Ljava/io/IOException;-><init>(Ljava/lang/String;)V

    throw v0
.end method


# virtual methods
.method public a_()V
    .locals 5

    invoke-super {p0}, Lcom/igexin/b/a/d/d;->a_()V

    const/16 v0, 0xa

    invoke-static {v0}, Landroid/os/Process;->setThreadPriority(I)V

    invoke-direct {p0}, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->g()Ljava/lang/String;

    move-result-object v0

    new-instance v1, Ljava/io/FileOutputStream;

    new-instance v2, Ljava/io/File;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->b:Ljava/io/File;

    sget-object v4, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->b:Ljava/lang/String;

    invoke-direct {v2, v3, v4}, Ljava/io/File;-><init>(Ljava/io/File;Ljava/lang/String;)V

    invoke-direct {v1, v2}, Ljava/io/FileOutputStream;-><init>(Ljava/io/File;)V

    const-string v2, "utf-8"

    invoke-virtual {v0, v2}, Ljava/lang/String;->getBytes(Ljava/lang/String;)[B

    move-result-object v0

    invoke-virtual {v1, v0}, Ljava/io/FileOutputStream;->write([B)V

    invoke-virtual {v1}, Ljava/io/FileOutputStream;->flush()V

    invoke-virtual {v1}, Ljava/io/FileOutputStream;->close()V

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    invoke-virtual {v0, p0}, Lcom/igexin/b/a/b/c;->a(Ljava/lang/Object;)Z

    invoke-static {}, Lcom/igexin/b/a/b/c;->b()Lcom/igexin/b/a/b/c;

    move-result-object v0

    invoke-virtual {v0}, Lcom/igexin/b/a/b/c;->c()V

    return-void
.end method

.method public final b()I
    .locals 1

    const v0, -0x88801

    return v0
.end method

.method protected e()V
    .locals 0

    return-void
.end method
