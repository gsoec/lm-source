.class Lcom/igexin/push/extension/distribution/basic/util/webview/g;
.super Ljava/lang/Object;


# static fields
.field static a:Ljava/lang/String;

.field static b:Ljava/lang/String;


# instance fields
.field c:Ljava/lang/String;

.field d:Ljava/lang/String;

.field e:Ljava/lang/String;

.field f:Ljava/lang/String;

.field g:Lcom/igexin/b/a/b/c;

.field h:I

.field i:Lcom/igexin/push/extension/distribution/basic/util/webview/e;

.field j:I

.field k:I

.field l:I

.field m:Ljava/lang/String;

.field n:Z


# direct methods
.method static constructor <clinit>()V
    .locals 1

    sget-object v0, Lcom/igexin/push/core/a;->b:Ljava/lang/String;

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->a:Ljava/lang/String;

    const-string v0, "1.html"

    sput-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->b:Ljava/lang/String;

    return-void
.end method

.method constructor <init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lcom/igexin/b/a/b/c;ILcom/igexin/push/extension/distribution/basic/util/webview/e;)V
    .locals 0

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    iput-object p1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->c:Ljava/lang/String;

    iput-object p2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->d:Ljava/lang/String;

    iput-object p3, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->e:Ljava/lang/String;

    iput-object p4, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->f:Ljava/lang/String;

    iput-object p5, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->g:Lcom/igexin/b/a/b/c;

    iput p6, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->h:I

    iput-object p7, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->i:Lcom/igexin/push/extension/distribution/basic/util/webview/e;

    return-void
.end method


# virtual methods
.method a(Lcom/igexin/push/extension/distribution/basic/util/webview/f;Ljava/lang/Exception;)V
    .locals 8

    const/4 v0, 0x1

    iput-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->n:Z

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->i:Lcom/igexin/push/extension/distribution/basic/util/webview/e;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->e:Ljava/lang/String;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->f:Ljava/lang/String;

    iget-object v4, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->m:Ljava/lang/String;

    iget-object v5, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->c:Ljava/lang/String;

    iget-object v6, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->d:Ljava/lang/String;

    move-object v1, p1

    move-object v7, p2

    invoke-interface/range {v0 .. v7}, Lcom/igexin/push/extension/distribution/basic/util/webview/e;->a(Lcom/igexin/push/extension/distribution/basic/util/webview/f;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Exception;)V

    return-void
.end method

.method a()Z
    .locals 1

    iget-boolean v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->n:Z

    return v0
.end method

.method a(Lcom/igexin/b/a/d/a/e;Lcom/igexin/b/a/d/e;)Z
    .locals 9

    const/4 v3, 0x0

    const/4 v8, 0x0

    const/4 v7, 0x1

    invoke-interface {p1}, Lcom/igexin/b/a/d/a/e;->b()I

    move-result v0

    sparse-switch v0, :sswitch_data_0

    :cond_0
    :goto_0
    return v7

    :sswitch_0
    check-cast p1, Lcom/igexin/push/extension/distribution/basic/util/webview/c;

    new-instance v0, Ljava/io/File;

    iget-object v1, p1, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->b:Ljava/io/File;

    sget-object v2, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->b:Ljava/lang/String;

    invoke-direct {v0, v1, v2}, Ljava/io/File;-><init>(Ljava/io/File;Ljava/lang/String;)V

    invoke-virtual {v0}, Ljava/io/File;->getAbsolutePath()Ljava/lang/String;

    move-result-object v0

    iput-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->m:Ljava/lang/String;

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->d:Ljava/util/Queue;

    if-eqz v0, :cond_1

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->d:Ljava/util/Queue;

    invoke-interface {v0}, Ljava/util/Queue;->isEmpty()Z

    move-result v0

    if-nez v0, :cond_1

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->d:Ljava/util/Queue;

    invoke-interface {v0}, Ljava/util/Queue;->size()I

    move-result v0

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->j:I

    iput v8, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->l:I

    iput v8, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->k:I

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->d:Ljava/util/Queue;

    invoke-interface {v0}, Ljava/util/Queue;->iterator()Ljava/util/Iterator;

    move-result-object v1

    :goto_1
    invoke-interface {v1}, Ljava/util/Iterator;->hasNext()Z

    move-result v0

    if-eqz v0, :cond_0

    invoke-interface {v1}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/igexin/push/extension/distribution/basic/util/webview/a;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->g:Lcom/igexin/b/a/b/c;

    new-instance v3, Lcom/igexin/push/extension/distribution/basic/h/a;

    new-instance v4, Lcom/igexin/push/extension/distribution/basic/util/webview/b;

    iget-object v5, v0, Lcom/igexin/push/extension/distribution/basic/util/webview/a;->b:Ljava/lang/String;

    iget-object v0, v0, Lcom/igexin/push/extension/distribution/basic/util/webview/a;->a:Ljava/lang/String;

    iget-object v6, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->e:Ljava/lang/String;

    invoke-direct {v4, v5, v0, v6, v7}, Lcom/igexin/push/extension/distribution/basic/util/webview/b;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;I)V

    invoke-direct {v3, v4}, Lcom/igexin/push/extension/distribution/basic/h/a;-><init>(Lcom/igexin/push/extension/distribution/basic/h/f;)V

    invoke-virtual {v2, v3, v8, v7}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    goto :goto_1

    :cond_1
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->a:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    invoke-virtual {p0, v0, v3}, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->a(Lcom/igexin/push/extension/distribution/basic/util/webview/f;Ljava/lang/Exception;)V

    goto :goto_0

    :sswitch_1
    check-cast p1, Lcom/igexin/push/extension/distribution/basic/util/webview/b;

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->k:I

    add-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->k:I

    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->k:I

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->l:I

    add-int/2addr v0, v1

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->j:I

    if-lt v0, v1, :cond_0

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->a:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    invoke-virtual {p0, v0, v3}, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->a(Lcom/igexin/push/extension/distribution/basic/util/webview/f;Ljava/lang/Exception;)V

    goto :goto_0

    nop

    :sswitch_data_0
    .sparse-switch
        -0x88801 -> :sswitch_0
        0x88802 -> :sswitch_1
    .end sparse-switch
.end method

.method a(Lcom/igexin/b/a/d/d;Lcom/igexin/b/a/d/e;)Z
    .locals 8

    const/4 v7, 0x1

    invoke-virtual {p1}, Lcom/igexin/b/a/d/d;->b()I

    move-result v0

    sparse-switch v0, :sswitch_data_0

    :cond_0
    :goto_0
    return v7

    :sswitch_0
    check-cast p1, Lcom/igexin/push/extension/distribution/basic/util/webview/c;

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->B:Ljava/lang/Exception;

    instance-of v0, v0, Ljava/io/FileNotFoundException;

    if-eqz v0, :cond_1

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->c:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    iget-object v1, p1, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->B:Ljava/lang/Exception;

    invoke-virtual {p0, v0, v1}, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->a(Lcom/igexin/push/extension/distribution/basic/util/webview/f;Ljava/lang/Exception;)V

    goto :goto_0

    :cond_1
    sget-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->b:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    iget-object v1, p1, Lcom/igexin/push/extension/distribution/basic/util/webview/c;->B:Ljava/lang/Exception;

    invoke-virtual {p0, v0, v1}, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->a(Lcom/igexin/push/extension/distribution/basic/util/webview/f;Ljava/lang/Exception;)V

    goto :goto_0

    :sswitch_1
    check-cast p1, Lcom/igexin/push/extension/distribution/basic/h/a;

    iget-object v0, p1, Lcom/igexin/push/extension/distribution/basic/h/a;->a:Lcom/igexin/push/extension/distribution/basic/h/f;

    if-eqz v0, :cond_0

    invoke-virtual {v0}, Lcom/igexin/push/extension/distribution/basic/h/f;->b()I

    move-result v1

    packed-switch v1, :pswitch_data_0

    goto :goto_0

    :pswitch_0
    check-cast v0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;

    iget v1, v0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->j:I

    const/4 v2, 0x3

    if-ge v1, v2, :cond_2

    iget-object v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->g:Lcom/igexin/b/a/b/c;

    new-instance v2, Lcom/igexin/push/extension/distribution/basic/h/a;

    new-instance v3, Lcom/igexin/push/extension/distribution/basic/util/webview/b;

    iget-object v4, v0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->h:Ljava/lang/String;

    iget-object v5, v0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->a:Ljava/lang/String;

    iget-object v6, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->e:Ljava/lang/String;

    iget v0, v0, Lcom/igexin/push/extension/distribution/basic/util/webview/b;->j:I

    add-int/lit8 v0, v0, 0x1

    invoke-direct {v3, v4, v5, v6, v0}, Lcom/igexin/push/extension/distribution/basic/util/webview/b;-><init>(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;I)V

    invoke-direct {v2, v3}, Lcom/igexin/push/extension/distribution/basic/h/a;-><init>(Lcom/igexin/push/extension/distribution/basic/h/f;)V

    const/4 v0, 0x0

    invoke-virtual {v1, v2, v0, v7}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    :goto_1
    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->k:I

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->l:I

    add-int/2addr v0, v1

    iget v1, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->j:I

    if-lt v0, v1, :cond_0

    sget-object v0, Lcom/igexin/push/extension/distribution/basic/util/webview/f;->d:Lcom/igexin/push/extension/distribution/basic/util/webview/f;

    const/4 v1, 0x0

    invoke-virtual {p0, v0, v1}, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->a(Lcom/igexin/push/extension/distribution/basic/util/webview/f;Ljava/lang/Exception;)V

    goto :goto_0

    :cond_2
    iget v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->l:I

    add-int/lit8 v0, v0, 0x1

    iput v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->l:I

    goto :goto_1

    nop

    :sswitch_data_0
    .sparse-switch
        -0x7ffffff7 -> :sswitch_1
        -0x88801 -> :sswitch_0
    .end sparse-switch

    :pswitch_data_0
    .packed-switch 0x88802
        :pswitch_0
    .end packed-switch
.end method

.method b()V
    .locals 5

    new-instance v0, Ljava/io/File;

    sget-object v1, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->a:Ljava/lang/String;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->e:Ljava/lang/String;

    invoke-static {v2}, Ljava/lang/String;->valueOf(Ljava/lang/Object;)Ljava/lang/String;

    move-result-object v2

    invoke-direct {v0, v1, v2}, Ljava/io/File;-><init>(Ljava/lang/String;Ljava/lang/String;)V

    new-instance v1, Ljava/io/File;

    const-string v2, "res/"

    invoke-direct {v1, v0, v2}, Ljava/io/File;-><init>(Ljava/io/File;Ljava/lang/String;)V

    invoke-virtual {v1}, Ljava/io/File;->exists()Z

    move-result v2

    if-nez v2, :cond_0

    invoke-virtual {v1}, Ljava/io/File;->mkdirs()Z

    :cond_0
    new-instance v1, Lcom/igexin/push/extension/distribution/basic/util/webview/c;

    iget-object v2, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->e:Ljava/lang/String;

    iget-object v3, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->f:Ljava/lang/String;

    iget v4, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->h:I

    invoke-direct {v1, v2, v3, v4, v0}, Lcom/igexin/push/extension/distribution/basic/util/webview/c;-><init>(Ljava/lang/String;Ljava/lang/String;ILjava/io/File;)V

    iget-object v0, p0, Lcom/igexin/push/extension/distribution/basic/util/webview/g;->g:Lcom/igexin/b/a/b/c;

    const/4 v2, 0x0

    const/4 v3, 0x1

    invoke-virtual {v0, v1, v2, v3}, Lcom/igexin/b/a/b/c;->a(Lcom/igexin/b/a/d/d;ZZ)Z

    return-void
.end method
